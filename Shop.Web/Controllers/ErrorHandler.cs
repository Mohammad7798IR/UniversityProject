using Microsoft.AspNetCore.Mvc;

namespace Shop.Web.Controllers
{
    public class ErrorHandler : Controller
    {
        public IActionResult Index(int? statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("_NotFound");
                default:
                    break;
            }
            return View();
        }
    }
}
