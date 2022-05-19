using Shop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTOs.UserPanel
{
    public class UserSideBarDTO
    {
        public UserSideBarDTO()
        {
            RoleIds = new List<ApplicationUserRole>();
        }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public List<ApplicationUserRole> RoleIds { get; set; }
    }
}
