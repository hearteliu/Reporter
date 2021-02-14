using log4net;
using Reporter.Interfaces;
using System;
using System.Data;
using System.IO;
using System.Linq;

namespace Reporter.Services
{
    public class CsvService : ICsvService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DatabaseService));

        /// <summary>
        /// Gets a DataTable out of the csv file represented by pathToFile
        /// </summary>
        /// <param name="pathToFile">The path to file</param>
        /// <returns>A DataTable</returns>
        public DataTable GetDataTableOutOfCsvFile(string pathToFile)
        {
            var dataTable = new DataTable();

            if (string.IsNullOrWhiteSpace(pathToFile))
                return dataTable;

            dataTable.Columns.AddRange(
                new DataColumn[Reporter.Resources.Constants.Settings.CsvNumberOfColumns] {
                new DataColumn(Resources.Constants.ColumnNames.CustomerId, typeof(int)),
                new DataColumn(Resources.Constants.ColumnNames.Forename, typeof(string)),
                new DataColumn(Resources.Constants.ColumnNames.Surname, typeof(string)),
                new DataColumn(Resources.Constants.ColumnNames.DateOfBirth, typeof(DateTime)),
                new DataColumn(Resources.Constants.ColumnNames.VehicleId, typeof(int)),
                new DataColumn(Resources.Constants.ColumnNames.Manufacturer, typeof(string)),
                new DataColumn(Resources.Constants.ColumnNames.Model, typeof(string)),
                new DataColumn(Resources.Constants.ColumnNames.RegistrationNumber, typeof(string)),
                new DataColumn(Resources.Constants.ColumnNames.EngineSize, typeof(int)),
                new DataColumn(Resources.Constants.ColumnNames.RegistrationDate, typeof(DateTime)),
                new DataColumn(Resources.Constants.ColumnNames.InteriorColor,typeof(string)) });

            try
            {
                //Read the contents of CSV file.
                string csvData = File.ReadAllText(pathToFile);

                var rows = csvData.Split(Resources.Constants.Delimiters.NewLine);

                //Execute a loop over the rows.
                foreach (string row in rows.ToList().GetRange(1, rows.Count() - 1))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dataTable.Rows.Add();

                        var i = 0;

                        //Execute a loop over the columns.
                        foreach (string cell in row.Split(Resources.Constants.Delimiters.Comma))
                        {
                            dataTable.Rows[dataTable.Rows.Count - 1][i] = cell;
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            return dataTable;
        }
    }
}
