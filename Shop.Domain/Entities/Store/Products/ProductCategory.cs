using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.MarketPlaceStore.Products
{
    public partial class ProductCategory : BaseEntity
    {
    }

    #region relations 

    public partial class ProductCategory
    {
        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }
    }

    #endregion
}
