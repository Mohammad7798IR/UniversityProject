using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Extentions;
using Shop.Application.Interfaces;
using Shop.Domain.DTOs.UserPanel;
using Shop.Domain.Entities.Identity;
using System.Security.Claims;

namespace Shop.Web.Areas.User.ViewComponents
{
    public class SupportAgentInformationViewComponent : ViewComponent
    {
        private readonly IUserservice _userservice;

        public SupportAgentInformationViewComponent(IUserservice userservice)
        {
            _userservice = userservice;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userservice.FindUserById(UserClaimsPrincipal.GetUserId());

            var userInfoDTO = new UserInformationDTO()
            {
                Avatar = user.Avatar,
                BirthDate = user.BirthDate,
                Email = user.Email,
                FullName = user.FirstName + "  " + user.LastName,
                PhoneNumber = user.PhoneNumber,
            };

            return View("SupportAgentInformation", userInfoDTO);
        }
    }
    public class SupportAgentSideBarViewComponent : ViewComponent
    {
        private readonly IUserservice _userservice;
        
        public SupportAgentSideBarViewComponent(IUserservice userservice)
        {
            _userservice = userservice;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var user = await _userservice.FindUserById(UserClaimsPrincipal.GetUserId());

            var sideBarDTO = new UserSideBarDTO()
            {
                Email = user.Email,
                FullName = user.FirstName + "  " + user.LastName,
                Avatar = user.Avatar,
                
            };

            return View("SupportAgentSideBar", sideBarDTO);
        }
    }
}
