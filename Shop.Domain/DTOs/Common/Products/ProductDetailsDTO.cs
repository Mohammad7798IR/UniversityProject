using Shop.Domain.Entities.MarketPlaceStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTOs.Common.Products
{
    public class ProductDetailsDTO
    {
        public Product Product { get; set; }

        public ICollection<ProductGallery> ProductGalleries { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

        public bool Result { get; set; }
    }
}
