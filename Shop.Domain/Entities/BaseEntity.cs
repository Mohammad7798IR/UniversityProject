using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string CreatedAt { get; set; }

      
        public string? UpdatedAt { get; set; }


        public bool IsDeleted { get; set; }
    }
}
