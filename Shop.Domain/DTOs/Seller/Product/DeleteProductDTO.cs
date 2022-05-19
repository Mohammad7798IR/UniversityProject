using Shop.Domain.Entities.MarketPlaceStore.Products;

namespace Shop.Domain.DTOs.Seller.StoreProduct
{
    public class DeleteProductDTO
    {
        public Product? Product { get; set; }

        public bool Result { get; set; }
    }
}
