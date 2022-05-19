using Microsoft.AspNetCore.Mvc;

namespace Shop.Web.Areas.SupportAgent.Controllers
{
    public class HomeController : SupportAgentBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
