using Reporter.Models;
using System.Collections.Generic;

namespace Reporter.Interfaces
{
    public interface IImporterService
    {
        /// <summary>
        /// Imports the list of customers to the database
        /// </summary>
        /// <param name="customers">The list of customers</param>
        void ImportCustomers(List<CustomerModel> customers);
    }
}
