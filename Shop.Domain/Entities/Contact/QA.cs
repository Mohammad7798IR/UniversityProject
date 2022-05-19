using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Contact
{
    public partial class QA : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Question { get; set; }

        
        [Required]
        [MaxLength(500)]
        public string Answer { get; set; }
    }


    #region Relations
    public partial class QA
    {
        //public string ParentId { get; set; }

        //public QA Parent { get; set; }
    }
    #endregion
}
