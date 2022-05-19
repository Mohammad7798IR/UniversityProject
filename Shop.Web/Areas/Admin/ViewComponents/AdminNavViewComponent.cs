using Microsoft.AspNetCore.Mvc;
using Shop.Application.Extentions;
using Shop.Application.Interfaces;
using Shop.Domain.DTOs.Admin;

namespace MarketPlace.Host.Areas.Admin.ViewComponents
{
    public class AdminNavViewComponent : ViewComponent
    {
        private readonly IUserservice _userService;

        public AdminNavViewComponent(IUserservice userServices)
        {
            _userService = userServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        
        {
            var user = await _userService.GetUserAsync(UserClaimsPrincipal.GetUserId());

            var adminDto = new AdminNavDetailsDTO()
            {
                FullName = user.FirstName + " " + user.LastName,
                Avatar   = user.Avatar,
                Email    = user.Email,
            };


            return View("_AdminNaveBarSection", adminDto);
        }
    }
}
