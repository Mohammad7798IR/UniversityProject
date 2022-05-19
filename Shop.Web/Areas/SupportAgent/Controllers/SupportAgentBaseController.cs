using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Web.Areas.SupportAgent.Controllers
{
    [Authorize(Roles = "AplicationSupport")]
    [Area("SupportAgent")]
    public class SupportAgentBaseController : Controller
    {
 
        protected string ErrorMessage = "ErrorMessage";
        protected string SuccessMessage = "SuccessMessage";
        protected string InfoMessage = "InfoMessage";
        protected string WarningMessage = "WarningMessage";

    }
}
