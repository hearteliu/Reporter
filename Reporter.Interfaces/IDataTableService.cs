using Reporter.Models;
using System.Collections.Generic;
using System.Data;

namespace Reporter.Interfaces
{
    public interface IDataTableService
    {
        /// <summary>
        /// Gets the customers out of DataTable
        /// </summary>
        /// <param name="dataTable">The DataTable</param>
        /// <returns>A list of CustomerModel</returns>
        List<CustomerModel> GetCustomersOutOfDataTable(DataTable dataTable);
    }
}
