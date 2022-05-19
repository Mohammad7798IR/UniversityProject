using Microsoft.AspNetCore.Mvc;
using Shop.Application.Extentions;
using Shop.Application.Interfaces;
using Shop.Application.Interfaces.Seller;
using Shop.Domain.DTOs.Seller.StoreProduct;

namespace Shop.Web.Areas.Seller.Controllers
{
    public partial class HomeController : SellerBaseController
    {
        private readonly ISellerService _sellerService;
        private readonly IUserservice _userService;

        public HomeController(ISellerService sellerService, IUserservice userService)
        {
            _sellerService = sellerService;
            _userService = userService;
        }
    }
    public partial class HomeController
    {
        public IActionResult Index()
        {
            return View();
        }


        #region Product



        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.categories = await _sellerService.GetAllCategories();
            return View();
        }


        [HttpPost]
        [Route("CreateProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(IFormFile postedFile, CreateProductDTO createProductDTO)
        {
            if (ModelState.IsValid)
            {
                var store = await _userService.GetStore(User.GetUserId());
                var result = await _sellerService.CreateProduct(postedFile, createProductDTO, store.Id);

                switch (result)
                {
                    case CreateProductResult.Success:
                        TempData[SuccessMessage] = $"محصول مورد نظر با عنوان {createProductDTO.ProductName} با موفقیت ثبت شد";
                        return RedirectToAction("Index");

                    case CreateProductResult.Fail:
                        TempData[ErrorMessage] = "عملیات ثبت محصول با خطا مواجه شد";
                        break;

                    case CreateProductResult.HasNoImage:
                        TempData[WarningMessage] = "لطفا تصویر محصول را وارد نمایید";
                        break;

                    default:
                        break;
                }

            }
            ViewBag.Categories = await _sellerService.GetAllCategories();
            return View();
        }


        [HttpGet]
        [Route("EditProduct/{productId}")]
        public async Task<IActionResult> EditProduct(string productId)
        {
            return View(await _sellerService.GetInfoEditProduct(productId));
        }


        [HttpPost]
        [Route("EditProduct/{productId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(EditProductDTO editProductDTO, IFormFile postedFile)
        {

            var result = await _sellerService.EditProduct(editProductDTO, User.GetUserId(), editProductDTO.ProductId, postedFile);

            switch (result)
            {
                case EditProductResult.InvalidStore:
                    TempData[ErrorMessage] = "در ویرایش اطلاعات خطایی رخ داد";
                    return RedirectToAction("FilterProducts");

                case EditProductResult.ProductNotFound:
                    TempData[WarningMessage] = "اطلاعات وارد شده یافت نشد";
                    return RedirectToAction("FilterProducts");

                case EditProductResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterProducts");
            }

            return View();
        }


        [HttpGet]
        [Route("DeleteProudct/{productId}")]
        public async Task<IActionResult> DeleteProduct(string productId)
        {

            var result = await _sellerService.DeleteProduct(productId);

            if (result.Result)
            {
                TempData[SuccessMessage] = $"محصول مورد نظر با عنوان {result.Product.Title} حذف  شد";
                return RedirectToAction("FilterProducts");
            }



            if (!result.Result)
            {
                TempData[ErrorMessage] = "عملیات ثبت محصول با خطا مواجه شد";
                return RedirectToAction("FilterProducts");
            }

            return View();
        }


        [HttpGet]
        [Route("FilterProducts")]
        public async Task<IActionResult> FilterProducts(FilterSellerProductDTO filterProductDTO)
        {
            var store = await _userService.GetStore(User.GetUserId());

            var result = await _sellerService.FilterProduct(filterProductDTO, store.Id);

            return View(result);
        }


        #endregion


        #region ProductGallery

        [HttpGet]
        [Route("GetProductGalleries/{productId}")]
        public async Task<IActionResult> GetProductGalleries(string productId)
        {
            ViewBag.productId = productId;
            return View(await _sellerService.GetAllProductGalleriesByProductId(productId));
        }


        [HttpGet]
        [Route("CreateProductGallery/{productId}")]
        public async Task<IActionResult> CreateProductGallery(string productId)
        {
            var product = await _sellerService.GetProductByOwnerIdAndProductId(productId, User.GetUserId());

            if (product == null) return NotFound();

            ViewBag.product = product;

            return View();
        }



        [Route("CreateProductGallery/{productId}")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateProductGallery(CreateProductGalleryDTO createProductGalleryDTO, IFormFile postedFile, string productId)
        {

            var result = await _sellerService.CreateProductGallery(createProductGalleryDTO, postedFile, productId, User.GetUserId());


            switch (result)
            {
                case CreateProductGalleryResult.success:
                    TempData[SuccessMessage] = "عملیات ثبت گالری محصول با موفقیت انجام شد";
                    return Redirect("/seller");

                case CreateProductGalleryResult.failure:
                    TempData[ErrorMessage] = "مشکلی پیش امد لطفا دوباره تلاش کنید";
                    break;
                case CreateProductGalleryResult.HasNoImage:
                    TempData[WarningMessage] = "تصویر مربوطه را وارد نمایید";
                    break;
                case CreateProductGalleryResult.InvalidStore:
                    TempData[ErrorMessage] = "محصول مورد نظر در لیست محصولات شما یافت نشد";
                    break;
                default:
                    break;
            }
            return View();
        }


        [Route("EditProductGallery/{productGalleryId}")]
        public async Task<IActionResult> EditProductGallery(string productGalleryId)
        {

            var reuslt = await _sellerService.GetProductGalleryForEdit(productGalleryId, User.GetUserId());

            ViewBag.product = reuslt.Product;

            return View(reuslt);
        }

        [ValidateAntiForgeryToken]
        [Route("EditProductGallery/{productGalleryId}")]
        [HttpPost]
        public async Task<IActionResult> EditProductGallery(CreateProductGalleryDTO createProductGalleryDTO, IFormFile postedFile, string productGalleryId)
        {
            if (ModelState.IsValid)
            {
                var result = await _sellerService.EditProductGallery(createProductGalleryDTO, productGalleryId, User.GetUserId(), postedFile);

                switch (result)
                {
                    case CreateProductGalleryResult.success:
                        TempData[SuccessMessage] = "عملیات ویرایش گالری محصول با موفقیت انجام شد";
                        return Redirect("/seller");

                    case CreateProductGalleryResult.failure:
                        TempData[ErrorMessage] = "مشکلی پیش امد لطفا دوباره تلاش کنید";
                        break;
                    case CreateProductGalleryResult.HasNoImage:
                        TempData[WarningMessage] = "تصویر مربوطه را وارد نمایید";
                        break;
                    case CreateProductGalleryResult.InvalidStore:
                        TempData[ErrorMessage] = "محصول مورد نظر در لیست محصولات شما یافت نشد";
                        break;
                    default:
                        break;
                }


            }

            return View();
        }

        #endregion
    }
}
