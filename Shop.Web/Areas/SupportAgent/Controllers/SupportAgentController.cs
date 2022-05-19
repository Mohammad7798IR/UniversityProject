using Microsoft.AspNetCore.Mvc;
using Shop.Application.Extentions;
using Shop.Application.Interfaces;
using Shop.Web.Areas.SupportAgent.Controllers;

namespace Shop.Web.Areas.User.Controllers
{
    public class SupportAgentController : SupportAgentBaseController
    {
        private readonly IUserservice _userservice;

        public SupportAgentController(IUserservice userservice)
        {
            _userservice = userservice;
        }

        [HttpGet]
        [Route("ChatWithSupport")]
        public async Task<IActionResult> ChatWithSupport()
        {
            return View(await _userservice.FindUserById(User.GetUserId()));
        }
    }
}
