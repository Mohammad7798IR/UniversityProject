using Shop.Domain.Entities.MarketPlaceStore.Products;


namespace Shop.Domain.Interfaces
{
    public interface IProductRepository
    {

        Task<Product> GetProductAndProductGalleriesByProductId(string productId);

        Task<Product> GetProductAndProductCategoriesByProductId(string productId);
    }
}
