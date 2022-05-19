using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTOs.Admin
{
    public class AdminNavDetailsDTO
    {

        public string Avatar { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }
    }
    public enum AvatarResult
    {
        success,
        failure,
        notFound,
        notImage
    }
}
