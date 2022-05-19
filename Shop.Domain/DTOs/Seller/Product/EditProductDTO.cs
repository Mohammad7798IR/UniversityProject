using Shop.Domain.Entities.MarketPlaceStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTOs.Seller.StoreProduct
{
    public class EditProductDTO : CreateProductDTO
    {
        public Product Product { get; set; }

        public List<Category> Categories { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }

        public bool Result { get; set; }

        public string ProductId { get; set; }
    }

    public enum EditProductResult
    {
        ProductNotFound,
        InvalidUser,
        Success,
        InvalidStore,
        NoImage,
        NotImage
    }
}
