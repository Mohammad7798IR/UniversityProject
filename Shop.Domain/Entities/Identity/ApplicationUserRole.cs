using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Identity
{
    public partial class ApplicationUserRole:IdentityUserRole<string>
    {
        [Key]
        public string Id { get; set; }
    }

    #region Relations
    public partial class ApplicationUserRole
    {
        public ApplicationUser user { get; set; }

        public ApplicationRole role { get; set; }
    }

    #endregion
   
}
