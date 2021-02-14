using System.Web;

namespace Reporter.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Saves the chosen file to disk
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="targetFolder">The path to the target folder</param>
        /// <returns>A string representing the path to the file</returns>
        string SaveToDisk(HttpPostedFileBase file, string targetFolder);
    }
}
