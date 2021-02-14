using log4net;
using Reporter.Interfaces;
using Reporter.Models;
using System;
using System.Collections.Generic;

namespace Reporter.Services
{
    public class ImporterService : IImporterService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DatabaseService));
        private readonly IDatabaseService databaseService;

        public ImporterService(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        /// <summary>
        /// Imports the list of customers to the database
        /// </summary>
        /// <param name="customers">The list of customers</param>
        /// <returns>The list of imported customers</returns>
        public void ImportCustomers(List<CustomerModel> customers)
        {
            if (customers == null || customers.Count == 0)
                return;

            try
            {
                //iterate over customers
                foreach (var customer in customers)
                {
                    var customerAlreadyExists = databaseService.CheckCustomerExists(customer.CustomerId);

                    //save customer if it does not exist
                    if (!customerAlreadyExists)
                        databaseService.InsertCustomer(
                            customer.CustomerId,
                            customer.Forename,
                            customer.Surname,
                            customer.DateOfBirth);

                    //iterate over vehicles
                    foreach (var vehicle in customer.VehiclesOwned)
                    {
                        //check customer owns vehicle
                        var customerOwnsVehicle =
                            databaseService.CheckCustomerOwnsVehicle(customer.CustomerId,
                                                                     vehicle.VehicleId);

                        if (customerOwnsVehicle)
                            continue;

                        //check vehicle already exists
                        var vehicleAlreadyExists =
                            databaseService.CheckVehicleExists(vehicle.VehicleId);

                        //add vehicle
                        if (!vehicleAlreadyExists)
                            databaseService.InsertVehicle(vehicle.VehicleId,
                                vehicle.Manufacturer,
                                vehicle.Model,
                                vehicle.RegistrationNumber,
                                vehicle.RegistrationDate,
                                vehicle.EngineSize,
                                vehicle.InteriorColor);

                        //update customer vehicle
                        databaseService.AddCustomerVehicle(customer.CustomerId, vehicle.VehicleId);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
