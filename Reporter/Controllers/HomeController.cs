using log4net;
using Reporter.Interfaces;
using Reporter.Models;
using System;
using System.Web.Mvc;

namespace Reporter.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(HomeController));

        private readonly IFileService fileService;

        private readonly IImporterService importerService;

        private readonly IDataTableService dataTableService;

        private readonly ICsvService csvService;

        private readonly IDatabaseService databaseService;

        public HomeController(IFileService fileService,
                              IImporterService importerService,
                              IDataTableService dataTableService,
                              ICsvService csvService,
                              IDatabaseService databaseService)
        {
            this.fileService = fileService;
            this.importerService = importerService;
            this.dataTableService = dataTableService;
            this.csvService = csvService;
            this.databaseService = databaseService;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The Index method of the home controller.
        /// </summary>
        /// <param name="model">The HomePageViewModel</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Index(HomePageViewModel model)
        {
            try
            {
                //get the path to the file
                var pathToFile = fileService.SaveToDisk(model.File,
                    Server.MapPath(Reporter.Resources.Constants.File.PathToFilesFolder));

                //get a DataTable out of the file
                var dataTable = csvService.GetDataTableOutOfCsvFile(pathToFile);

                if (dataTable != null)
                {
                    //get customers from DataTable
                    var customers = dataTableService.GetCustomersOutOfDataTable(dataTable);

                    if (customers != null && customers.Count > 0)
                    {
                        //save customers to thatabase
                        importerService.ImportCustomers(customers);

                        return RedirectToAction(Resources.Constants.ActionNames.ReportActionName);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            return View();
        }

        /// <summary>
        /// The Report action which loads the report.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Report()
        {
            var model = new ReportPageViewModel();

            try
            {
                //get all customers from the database
                var importedCustomers = databaseService.GetAllCustomers();

                model.Customers = importedCustomers;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            return View(model);
        }
    }
}