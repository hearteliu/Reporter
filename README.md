# Reporter app

The Reporter app consists of the following projects:

Reporter -> the root MVC project; it contains ReporterEntities connection string in web.config

Reporter.Extensions -> the extensions project

Reporter.Interfaces -> the interfaces project

Reporter.Models -> the models project

Reporter.Repository -> the project that holds the entityframework .edmx data item and database generated files; it also contains ReporterEntities connection string in app.config

Reporter.Resources -> the resources project

Reporter.Services -> the services project

Reporter.SQL -> the project that contains the three scripts that will initialize the three tables of the Reporter database.

About the database:

A Database named 'Reporter' should be created.

Three tables should be added to the database. 

The scripts to create the three tables are in the Reporter.SQL project and are the following:

CreateCustomerAndVehiclesTable.sql, CreateCustomerInformationTable.sql, CreateVehicleInformationTable.sql

Entityframework is configured in the project Reporter.Repository
