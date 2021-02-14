using Reporter.Interfaces;
using Reporter.Models;
using Reporter.Repository;
using System;

namespace Reporter.Services
{
    public class ConverterService : IConverterService
    {
        /// <summary>
        /// Converts the customerInformation object to CustomerModel
        /// </summary>
        /// <param name="customerInformation">The customerInformation object</param>
        /// <returns>A CustomerModel</returns>
        public CustomerModel ConvertCustomerInformationToCustomerModel(CustomerInformation customerInformation)
        {
            var customerModel = new CustomerModel();

            if (customerInformation == null)
                return customerModel;

            customerModel.CustomerId = customerInformation.CustomerId;
            customerModel.Forename = customerInformation.Forename;
            customerModel.Surname = customerInformation.Surename;
            customerModel.DateOfBirth = customerInformation.DateOfBirth.HasValue
                ? customerInformation.DateOfBirth.Value 
                : DateTime.UtcNow;

            return customerModel;
        }

        /// <summary>
        /// Converts the vehicleInformation object to VehicleModel
        /// </summary>
        /// <param name="vehicleInformation">The vehicleInformation object</param>
        /// <returns>A VehicleModel</returns>
        public VehicleModel ConvertVehicleInformationToVehicleModel(VehicleInformation vehicleInformation)
        {
            var vehicleModel = new VehicleModel();

            if (vehicleInformation == null)
                return vehicleModel;

            vehicleModel.VehicleId = vehicleInformation.VehicleId;
            vehicleModel.Model = vehicleInformation.Model;
            vehicleModel.Manufacturer = vehicleInformation.Manufacturer;
            vehicleModel.RegistrationNumber = vehicleInformation.RegistrationNumber;
            vehicleModel.RegistrationDate = 
                vehicleInformation.RegistrationDate.HasValue 
                    ? vehicleInformation.RegistrationDate.Value 
                    : DateTime.UtcNow;
            vehicleModel.EngineSize = 
                vehicleInformation.EngineSize.HasValue 
                    ? vehicleInformation.EngineSize.Value 
                    : 0;
            vehicleModel.InteriorColor = vehicleInformation.InteriorColor;

            return vehicleModel;
        }
    }
}
