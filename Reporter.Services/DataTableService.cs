using log4net;
using Reporter.Interfaces;
using Reporter.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Reporter.Services
{
    public class DataTableService : IDataTableService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DataTableService));

        /// <summary>
        /// Gets the customers out of DataTable
        /// </summary>
        /// <param name="dataTable">The DataTable</param>
        /// <returns>A list of CustomerModel</returns>
        public List<CustomerModel> GetCustomersOutOfDataTable(DataTable dataTable)
        {
            var customers = new List<CustomerModel>();

            if (dataTable == null || dataTable.Rows.Count == 0)
                return customers;

            try
            {
                //iterate over the rows of the DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    //create a new CustomerModel object
                    var customer = new CustomerModel()
                    {
                        CustomerId =
                            row.Field<int>(Resources.Constants.ColumnNames.CustomerId),
                        Surname =
                            row.Field<string>(Resources.Constants.ColumnNames.Surname),
                        Forename =
                            row.Field<string>(Resources.Constants.ColumnNames.Forename),
                        DateOfBirth =
                            row.Field<DateTime>(Resources.Constants.ColumnNames.DateOfBirth)
                    };

                    //create a new VehicleModel object
                    var vehicle = new VehicleModel()
                    {
                        VehicleId =
                            row.Field<int>(Resources.Constants.ColumnNames.VehicleId),
                        RegistrationNumber =
                            row.Field<string>(Resources.Constants.ColumnNames.RegistrationNumber),
                        Model =
                            row.Field<string>(Resources.Constants.ColumnNames.Model),
                        Manufacturer
                           = row.Field<string>(Resources.Constants.ColumnNames.Manufacturer),
                        RegistrationDate
                          = row.Field<DateTime>(Resources.Constants.ColumnNames.RegistrationDate),
                        EngineSize
                           = row.Field<int>(Resources.Constants.ColumnNames.EngineSize),
                        InteriorColor
                           = row.Field<string>(Resources.Constants.ColumnNames.InteriorColor)
                    };

                    var vehicles = new List<VehicleModel>();

                    vehicles.Add(vehicle);

                    customer.VehiclesOwned = vehicles;

                    customers.Add(customer);
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
