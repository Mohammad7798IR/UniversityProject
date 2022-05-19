using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Application.Extentions;
using Shop.Application.Interfaces;
using System.Security.Claims;

namespace Shop.Application.Http
{
    public class CheckStoreState : AuthorizeAttribute, IAuthorizationFilter
    {
        private IUserservice _userservice;



        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            _userservice = (IUserservice)context.HttpContext.RequestServices.GetService(typeof(IUserservice));


            if (context.HttpContext.User.Identity.IsAuthenticated)
            {

                if (!await _userservice.HasUserGotAcceptedStoreByUserId(context.HttpContext.User.GetUserId()))
                {
                    context.HttpContext.Response.Redirect("/user");
                }
            }
        }
    }
}
