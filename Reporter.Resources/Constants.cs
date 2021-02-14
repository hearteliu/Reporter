using System;
using System.Collections.Generic;
using System.Text;

namespace Reporter.Resources
{
    public static class Constants
    {
        public static partial class Labels
        {
            /// <summary>
            /// The Upload CSV Label
            /// </summary>
            public const string UploadCsvLabel = "Upload CSV";

            /// <summary>
            /// The Import File Label
            /// </summary>
            public const string ImportFileLabel = "Import file";

            /// <summary>
            /// The report label
            /// </summary>
            public const string ReportLabel = "Report";

            /// <summary>
            /// The legend label
            /// </summary>
            public const string LegendLabel = "Legend";

            /// <summary>
            /// Young customer label
            /// </summary>
            public const string YoungCustomerLabel = "Young customer";

            /// <summary>
            /// Big engine label
            /// </summary>
            public const string BigEngineLabel = "Big engine";

            /// <summary>
            /// The old vehicle label
            /// </summary>
            public const string OldVehicleLabel = "Old car";

            /// <summary>
            /// The upload new CSV label
            /// </summary>
            public const string UploadNewCsvLabel = "Upload new CSV";
        }

        public static partial class File
        {
            /// <summary>
            /// The path to files folder
            /// </summary>
            public const string PathToFilesFolder = "~/App_Data/Imports";
        }

        public static partial class ErrorMessages
        {
            /// <summary>
            /// The select file message
            /// </summary>
            public const string PleaseSelectFile = "Please, select a file";
        }

        public static partial class ColumnNames
        {
            /// <summary>
            /// The CustomerId column
            /// </summary>
            public const string CustomerId = "CustomerId";

            /// <summary>
            /// The Forename column
            /// </summary>
            public const string Forename = "Forename";

            /// <summary>
            /// The Surname column
            /// </summary>
            public const string Surname = "Surname";

            /// <summary>
            /// The DateOfBirth column
            /// </summary>
            public const string DateOfBirth = "DateOfBirth";

            /// <summary>
            /// The VehicleId column
            /// </summary>
            public const string VehicleId = "VehicleId";

            /// <summary>
            /// The RegistrationNumber column
            /// </summary>
            public const string RegistrationNumber = "RegistrationNumber";

            /// <summary>
            /// The Manufacturer column
            /// </summary>
            public const string Manufacturer = "Manufacturer";

            /// <summary>
            /// The Model column
            /// </summary>
            public const string Model = "Model";

            /// <summary>
            /// The EngineSize column
            /// </summary>
            public const string EngineSize = "EnginieSize";

            /// <summary>
            /// The RegistrationDate column
            /// </summary>
            public const string RegistrationDate = "RegistrationDate";

            /// <summary>
            /// The Interior column
            /// </summary>
            public const string InteriorColor = "InteriorColor";
        }

        public static partial class Settings {
            /// <summary>
            /// The number of columns in the CSV file
            /// </summary>
            public const int CsvNumberOfColumns = 11;
        }

        public static partial class Delimiters
        {
            /// <summary>
            /// The comma delimiter
            /// </summary>
            public const char Comma = ',';

            /// <summary>
            /// The NewLine delimiter
            /// </summary>
            public const char NewLine = '\n';
        }

        public static partial class ActionNames
        {
            /// <summary>
            /// The report action name
            /// </summary>
            public const string ReportActionName = "Report";

            /// <summary>
            /// The index action name
            /// </summary>
            public const string IndexActionName = "Index";
        }

        public static partial class ControllerNames
        {
            /// <summary>
            /// The home controller name
            /// </summary>
            public const string HomeController = "Home";
        }
    }
}
