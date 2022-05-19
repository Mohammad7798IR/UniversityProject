using Microsoft.AspNetCore.Mvc;
using Shop.Application.Extentions;
using Shop.Application.Interfaces;
using Shop.Application.Interfaces.Seller;
using Shop.Domain.DTOs.Common;
using Shop.Domain.DTOs.UserPanel;

namespace Shop.Web.ViewComponents
{
    public class SiteFooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteFooter");
        }
    }



    public class SiteHeaderViewComponent : ViewComponent
    {

        private readonly IUserservice _userservice;

        public SiteHeaderViewComponent
            (
            IUserservice userservice
            )
        {
            _userservice = userservice;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var user = await _userservice.FindUserById(UserClaimsPrincipal.GetUserId());

            return View("SiteHeader", user);
        }
    }

    public class SiteSliderViewComponent : ViewComponent
    {

        private readonly ISiteService _siteService;

        public SiteSliderViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteSlider", await _siteService.GetAllActiveSliders());
        }
    }


    public class SiteCategoryViewComponent : ViewComponent
    {
        private readonly ISellerService _sellerService;

        public SiteCategoryViewComponent(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cat = await _sellerService.GetAllCategories();

            return View("SiteCategory",cat);
        }
    }
}
