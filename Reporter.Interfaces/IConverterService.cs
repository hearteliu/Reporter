using Reporter.Models;
using Reporter.Repository;

namespace Reporter.Interfaces
{
    public interface IConverterService
    {
        /// <summary>
        /// Converts the customerInformation object to CustomerModel
        /// </summary>
        /// <param name="customerInformation">The customerInformation object</param>
        /// <returns>A CustomerModel</returns>
        CustomerModel ConvertCustomerInformationToCustomerModel(CustomerInformation customerInformation);

        /// <summary>
        /// Converts the vehicleInformation object to VehicleModel
        /// </summary>
        /// <param name="vehicleInformation">The vehicleInformation object</param>
        /// <returns>A VehicleModel</returns>
        VehicleModel ConvertVehicleInformationToVehicleModel(VehicleInformation vehicleInformation);
    }
}
