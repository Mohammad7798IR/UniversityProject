using Microsoft.AspNetCore.Mvc;
using Shop.Application.Extentions;
using Shop.Application.Interfaces;
using Shop.Domain.DTOs.Seller;

namespace Shop.Web.Areas.Seller.ViewComponents
{
    public class SellerSideBarViewComponent : ViewComponent
    {
        private readonly IUserservice _userservice;

        public SellerSideBarViewComponent(IUserservice userservice)
        {
            _userservice = userservice;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userservice.FindUserById(UserClaimsPrincipal.GetUserId());


            var SellerSideBarDTO = new SellerSideBarDTO()
            {
                Avatar = user.Avatar,
                Email = user.Email,
                FullName = user.FirstName + " " + user.LastName,
            };

      
            return View("SellerSideBar",SellerSideBarDTO);
        }
    }
}
