using log4net;
using Reporter.Interfaces;
using System;
using System.IO;
using System.Web;

namespace Reporter.Services
{
    public class FileService : IFileService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(FileService));

        /// <summary>
        /// Saves the chosen file to disk
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="targetFolder">The path to the target folder</param>
        /// <returns>A string representing the path to the file</returns>
        public string SaveToDisk(HttpPostedFileBase file, string targetFolder)
        {
            if (file == null
                || file.ContentLength == 0
                || string.IsNullOrEmpty(targetFolder))
                return string.Empty;

            var path = string.Empty;

            try
            {
                var fileName = Path.GetFileName(file.FileName);

                path = Path.Combine(targetFolder, fileName);

                file.SaveAs(path);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }

            return path;
        }
    }
}
