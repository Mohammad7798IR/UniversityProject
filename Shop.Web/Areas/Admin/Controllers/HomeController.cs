using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.Admin;
using Shop.Domain.DTOs.Admin;
using Shop.Application.Http;
using Shop.Domain.DTOs.Common;

namespace Shop.Web.Areas.Admin.Controllers
{
    public partial class HomeController : AdminBaseController
    {
        private readonly IAdminService _adminService;

        public HomeController(IAdminService adminService)
        {
            _adminService = adminService;
        }

    }

    public partial class HomeController
    {


        public IActionResult Index()
        {
            TempData[ErrorMessage] = "مسلا";
            return View();
        }


        #region Store

        [HttpGet]
        [Route("StoreListRequest")]
        public async Task<IActionResult> StoreListRequest(FilterStoreDTO filterStoreDTO)
        {
            return View(await _adminService.FilterStores(filterStoreDTO));
        }


        [Route("AcceptStoreRequest/{storeId}")]
        public async Task<IActionResult> AcceptStoreRequest(string storeId)
        {
            var result = await _adminService.AcceptStore(storeId);

            if (result)
                return JsonResponse.SendStatus(JsonResponse.JsonResponseStatusType.Success, "درخواست مورد نظر با موفقیت تایید شد", null);

            return JsonResponse.SendStatus(JsonResponse.JsonResponseStatusType.Danger, "اطلاعاتی با این مشخصات یافت نشد", null);

        }

        [Route("RejectStoreRequest")]
        public async Task<IActionResult> RejectStoreRequest(RejectItemDTO rejectItem)
        {
            var result = await _adminService.RejectStoreRequest(rejectItem);

            if (result)
            {
                TempData[SuccessMessage] = "با موفقیت ثبت شد";
                return Redirect("StoreListRequest");
            }

            if (!result)
            {
                TempData[ErrorMessage] = "فروشگاهی با این اطلاعات پیدا نشد";
            }

            return Redirect("StoreListRequest");
        }

        #endregion




        #region Products

        [HttpGet]
        [Route("ProductsListRequest")]
        public async Task<IActionResult> ProductsListRequest(AdminFilterProductsDTO filterProductsDTO)
        {
            return View(await _adminService.FilterProducts(filterProductsDTO));
        }





        [Route("AcceptProductsListRequest/{productId}")]
        public async Task<IActionResult> AcceptProductsListRequest(string productId)
        {

            var result = await _adminService.AcceptProductRequest(productId);

            if (result)
            {
                return JsonResponse.SendStatus(JsonResponse.JsonResponseStatusType.Success, "درخواست مورد نظر با موفقیت تایید شد", null);
            }

            return JsonResponse.SendStatus(JsonResponse.JsonResponseStatusType.Danger, "اطلاعاتی با این مشخصات یافت نشد", null);
        }


        [Route("RejectProductRequest")]
        public async Task<IActionResult> RejectProductRequest(RejectItemDTO rejectItem)
        {

            var result = await _adminService.RejectProductRequest(rejectItem);

            if (result)
            {
                TempData[SuccessMessage] = "با موفقیت ثبت شد";
                return Redirect("ProductsListRequest");
            }

            if (!result)
            {
                TempData[ErrorMessage] = "محصولی با این اطلاعات پیدا نشد";
            }

            return View();
        }

        #endregion
    }
}
