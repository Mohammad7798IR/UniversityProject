using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Extentions;
using Shop.Application.Interfaces;
using Shop.Domain.DTOs.UserPanel;
using Shop.Domain.Entities.Identity;
using System.Security.Claims;

namespace Shop.Web.Areas.User.ViewComponents
{
    public class UserInformationViewComponent : ViewComponent
    {
        private readonly IUserservice _userservice;

        public UserInformationViewComponent(IUserservice userservice)
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

            return View("UserInformation", userInfoDTO);
        }
    }
    public class UserSideBarViewComponent : ViewComponent
    {
        private readonly IUserservice _userservice;

        public UserSideBarViewComponent(IUserservice userservice)
        {
            _userservice = userservice;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var user = await _userservice.FindUserAndRolesById(UserClaimsPrincipal.GetUserId());

            var sideBarDTO = new UserSideBarDTO();

            if (user.userRoles != null)
            {
                foreach (var item in user.userRoles)
                {
                    sideBarDTO.RoleIds.Add(item);
                }
            }

            sideBarDTO.Email = user.Email;
            sideBarDTO.FullName = user.FirstName + " " + user.LastName;
            sideBarDTO.Avatar = user.Avatar;

            return View("UserSideBar", sideBarDTO);
        }
    }
}
