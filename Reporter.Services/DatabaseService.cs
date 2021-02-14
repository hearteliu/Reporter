using log4net;
using Reporter.Interfaces;
using Reporter.Models;
using Reporter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reporter.Services
{
    public class DatabaseService : IDatabaseService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DatabaseService));

        private ReporterEntities reporterEntities = new ReporterEntities();

        private readonly IConverterService converterService;

        public DatabaseService(IConverterService converterService)
        {
            this.converterService = converterService;
        }

        /// <summary>
        /// Inserts a new customer into the database
        /// </summary>
        /// <param name="id">The customer ID</param>
        /// <param name="forename">The forename</param>
        /// <param name="surname">The surname</param>
        /// <param name="dateOfBirth">The date of birth</param>
        public void InsertCustomer(int id, string forename, string surname, DateTime dateOfBirth)
        {
            try
            {
                var customerInformation = new CustomerInformation()
                {
                    CustomerId = id,
                    Forename = forename,
                    Surename = surname,
                    DateOfBirth = dateOfBirth
                };

                reporterEntities.CustomerInformations.Add(customerInformation);

                reporterEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserts a new vehicle into the database
        /// </summary>
        /// <param name="id">The vehicle ID</param>
        /// <param name="manufacturer">The manufacturer</param>
        /// <param name="model">The model</param>
        /// <param name="registrationNumber">The registration number</param>
        /// <param name="registrationDate">The registration date</param>
        /// <param name="engineSize">The engine size</param>
        /// <param name="interiorColor">The interior color</param>
        public void InsertVehicle(int id,
                                  string manufacturer,
                                  string model,
                                  string registrationNumber,
                                  DateTime registrationDate,
                                  int engineSize,
                                  string interiorColor)
        {
            try
            {
                var vehicleInformation = new VehicleInformation()
                {
                    VehicleId = id,
                    Manufacturer = manufacturer,
                    Model = model,
                    RegistrationNumber = registrationNumber,
                    RegistrationDate = registrationDate,
                    EngineSize = engineSize,
                    InteriorColor = interiorColor
                };

                reporterEntities.VehicleInformations.Add(vehicleInformation);

                reporterEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Checks that the customer represented by customerId exists in the database
        /// </summary>
        /// <param name="customerId">The customer ID</param>
        /// <returns>tru if customer exists false otherwise</returns>
        public bool CheckCustomerExists(int customerId)
        {
            try
            {
                var customers =
                    reporterEntities.CustomerInformations.Where(el => el.CustomerId.Equals(customerId));

                return customers.Any();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);

                return false;
            }
        }

        /// <summary>
        /// Checks that the vehicle represented by vehicleId exists in the database
        /// </summary>
        /// <param name="vehicleId">The vehicle ID</param>
        /// <returns>tru if vehicle exists false otherwise</returns>
        public bool CheckVehicleExists(int vehicleId)
        {
            try
            {
                var vehicles =
                    reporterEntities.VehicleInformations.Where(el => el.VehicleId.Equals(vehicleId));

                return vehicles.Any();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);

                return false;
            }
        }

        /// <summary>
        /// Checks if the customer represented by customerId owns the vehicle
        /// represented by vehicleId
        /// </summary>
        /// <param name="customerId">The customer ID</param>
        /// <param name="vehicleId">The vehicle ID</param>
        /// <returns>true if customer owns vehicle false otherwise</returns>
        public bool CheckCustomerOwnsVehicle(int customerId, int vehicleId)
        {
            try
            {
                var customers =
                    reporterEntities.CustomerInformations.Where(el => el.CustomerId.Equals(customerId));

                if (customers == null || customers.Count() == 0)
                    return false;

                return
                    customers.FirstOrDefault().VehicleInformations.Any(el => el.VehicleId.Equals(vehicleId));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);

                return false;
            }
        }

        /// <summary>
        /// Adds the vehicle represented by vehicleId to the customer 
        /// represented by customerId
        /// </summary>
        /// <param name="customerId">The customer ID</param>
        /// <param name="vehicleId">The vehicle IDS</param>
        public void AddCustomerVehicle(int customerId, int vehicleId)
        {
            try
            {
                var customers = 
                    reporterEntities.CustomerInformations.Where(el => el.CustomerId.Equals(customerId));

                if (customers == null || customers.Count() == 0)
                    return;

                var customer = customers.FirstOrDefault();

                var vehicles =
                    reporterEntities.VehicleInformations.Where(el => el.VehicleId.Equals(vehicleId));

                if (vehicles == null || vehicles.Count() == 0)
                    return;

                var vehicle = vehicles.FirstOrDefault();

                customer.VehicleInformations.Add(vehicle);

                reporterEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }


        /// <summary>
        /// Gets all the customers from the database 
        /// </summary>
        /// <returns>A list of CustomerModel</returns>
        public List<CustomerModel> GetAllCustomers()
        {
            var customers = new List<CustomerModel>();

            try
            {
                var databaseCustomers = reporterEntities.CustomerInformations;

                foreach(var databaseCustomer in databaseCustomers)
                {
                    var customerModel = 
                        converterService.ConvertCustomerInformationToCustomerModel(databaseCustomer);

                    var vehicles = new List<VehicleModel>();

                    foreach(var databaseVehicle in databaseCustomer.VehicleInformations)
                    {
                        var vehicle =
                            converterService.ConvertVehicleInformationToVehicleModel(databaseVehicle);

                        vehicles.Add(vehicle);
                    }

                    customerModel.VehiclesOwned = vehicles;

                    customers.Add(customerModel);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            return customers;
        }
    }
}
