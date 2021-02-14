using Reporter.Models;
using System;
using System.Collections.Generic;

namespace Reporter.Interfaces
{
    public interface IDatabaseService
    {
        /// <summary>
        /// Inserts a new customer into the database
        /// </summary>
        /// <param name="id">The customer ID</param>
        /// <param name="forename">The forename</param>
        /// <param name="surname">The surname</param>
        /// <param name="dateOfBirth">The date of birth</param>
        void InsertCustomer(int id, string forename, string surname, DateTime dateOfBirth);

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
        void InsertVehicle(int id,
                           string manufacturer,
                           string model,
                           string registrationNumber,
                           DateTime registrationDate,
                           int engineSize,
                           string interiorColor);

        /// <summary>
        /// Checks that the customer represented by customerId exists in the database
        /// </summary>
        /// <param name="customerId">The customer ID</param>
        /// <returns>tru if customer exists false otherwise</returns>
        bool CheckCustomerExists(int customerId);

        /// <summary>
        /// Checks that the vehicle represented by vehicleId exists in the database
        /// </summary>
        /// <param name="vehicleId">The vehicle ID</param>
        /// <returns>tru if vehicle exists false otherwise</returns>
        bool CheckVehicleExists(int vehicleId);

        /// <summary>
        /// Checks if the customer represented by customerId owns the vehicle
        /// represented by vehicleId
        /// </summary>
        /// <param name="customerId">The customer ID</param>
        /// <param name="vehicleId">The vehicle ID</param>
        /// <returns>true if customer owns vehicle false otherwise</returns>
        bool CheckCustomerOwnsVehicle(int customerId, int vehicleId);

        /// <summary>
        /// Adds the vehicle represented by vehicleId to the customer 
        /// represented by customerId
        /// </summary>
        /// <param name="customerId">The customer ID</param>
        /// <param name="vehicleId">The vehicle IDS</param>
        void AddCustomerVehicle(int customerId, int vehicleId);

        /// <summary>
        /// Gets all the customers from the database 
        /// </summary>
        /// <returns>A list of CustomerModel</returns>
        List<CustomerModel> GetAllCustomers();
    }
}
