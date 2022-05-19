using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Http;

namespace Shop.Web.Areas.Seller.Controllers
{
    [Authorize(Roles = "AplicationSeller")]
    [Area("Seller")]
    //[CheckStoreState]
    public class SellerBaseController : Controller
    {
        protected string ErrorMessage = "ErrorMessage";
        protected string SuccessMessage = "SuccessMessage";
        protected string InfoMessage = "InfoMessage";
        protected string WarningMessage = "WarningMessage";
    }
}
