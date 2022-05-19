using Shop.Domain.Entities.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTOs.Contact
{
    public class QaDTO
    {
        public ICollection<QA> QAs { get; set; }
    }
}
