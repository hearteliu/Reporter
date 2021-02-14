using System.Data;

namespace Reporter.Interfaces
{
    public interface ICsvService
    {
        /// <summary>
        /// Gets a DataTable out of the csv file represented by pathToFile
        /// </summary>
        /// <param name="pathToFile">The path to file</param>
        /// <returns>A DataTable</returns>
        DataTable GetDataTableOutOfCsvFile(string pathToFile);
    }
}
