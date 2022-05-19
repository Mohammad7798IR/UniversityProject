using Microsoft.AspNetCore.Http;
using Shop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Extentions
{
    public static class UserExtention
    {


        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }


        public static string GetPersianDateTime(DateTime now)
        {
            var persianCalender = new PersianCalendar();

            return $"{persianCalender.GetYear(now)}/{persianCalender.GetMonth(now)}/{persianCalender.GetDayOfMonth(now)}";
        }
        public static string GetUserIp(this HttpContext httpContent)
        {
            return httpContent.Connection.RemoteIpAddress.ToString();
        }
    }
}
