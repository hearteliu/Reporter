using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Reporter.Models
{
    public class HomePageViewModel
    {
        /// <summary>
        /// The chosen file
        /// </summary>
        /// 
        [Required(ErrorMessage = 
            Reporter.Resources.Constants.ErrorMessages.PleaseSelectFile)]
        public HttpPostedFileBase File { get; set; }
    }
}