using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Extentions;
using Shop.Application.Interfaces;
using Shop.Domain.DTOs.Common.Products;
using Shop.Domain.DTOs.Contact;
using Shop.Web.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Shop.Web.Controllers
{
    public partial class HomeController : SiteBaseController
    {
        private readonly IContactService _contactService;
        private readonly IProductService _productService;
        public HomeController(IContactService contactService, IProductService productService)
        {
            _contactService = contactService;
            _productService = productService;
        }
    }

    public partial class HomeController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("AboutUs")]
        public async Task<ActionResult> AboutUs()
        {
            return View(await _contactService.GetAppSettingInfo());
        }


        #region QA

        [HttpGet]
        [Route("faq")]
        public async Task<IActionResult> QA()
        {
            return View(await _contactService.GetQAInfo());
        }

        #endregion


        #region ContactUs

        [Route("ContactUs")]
        public async Task<IActionResult> ContactUs()
        {

            return View(await _contactService.GetAppSettingInfoForContactUs());
        }

        [Route("ContactUs")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(ContactUsDTO contactUsDTO)
        {
            ModelState.Remove("SiteEmail");
            ModelState.Remove("SitePhoneNumber");
            if (ModelState.IsValid)
            {
                await _contactService.SubmitContactUs(contactUsDTO, User.GetUserId(), HttpContext.GetUserIp());

                TempData[SuccessMessage] = "پیام شما با موفقیت ارسال شد";
                TempData[InfoMessage] = "بزودی با شما تماس گرفته خواهد شد";

                return Redirect("/");
            }

            TempData[ErrorMessage] = " مشکلی پیش امد لطفا دوباره تلاش کنید !";

            return View();
        }

        #endregion



        #region ProductList


        [HttpGet]
        [Route("ProductList")]
        public async Task<IActionResult> ProductList(FilterProductsDTO filterProductsDTO)
        {
            return View(await _productService.FilterProducts(filterProductsDTO));
        }



        #endregion




        #region ProductDetails

        [HttpGet]
        [Route("ProductDetails/{productId}")]
        public async Task<IActionResult> ProductDetails(string productId)
        {
            return View(await _productService.ProductDetails(productId));
        }


        #endregion




        #region GetOrderDetails

        [HttpGet]
        [Route("GetOrderDetails")]
        [Authorize]
        public async Task<IActionResult> GetOrderDetails()
        {
            return View();
        }

        [HttpPost]
        [Route("AddOrderDetails/{productId}")]
        [Authorize]
        public async Task<IActionResult> AddOrderDetails(string productId)
        {
            return View();
        }

        #endregion
    }
}