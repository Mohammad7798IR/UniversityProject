using Shop.Domain.Entities.MarketPlaceStore.Products;


namespace Shop.Domain.Interfaces.Seller
{
    public partial interface ISellerRepository
    {
   
        Task AddProductCategory(List<ProductCategory> productCategory);

        Task<Product> FindProductAndProductCategoriesById(string productId);

        Task<Product> FindProductById(string productId);

        Task<List<ProductCategory>> FindProductCategoriesByProductId(string productId);

    }
    public partial interface ISellerRepository
    {
        Task<List<ProductGallery>> GetAllProductGalleriesByProductId(string productId);

        Task<List<ProductGallery>> GetAllProductGalleriesForStoreByProductId(string productId, string userId);
    }


    public partial interface ISellerRepository
    {
        Task<List<Category>> GetAllCategories();

        Task<Product> GetProductByProductIdAndOwnerId(string productId, string userId);

        Task<ProductGallery> GetProductGalleryByProductGalleryId(string productGalleryId , string userId);
    }

    public partial interface ISellerRepository
    {
        Task AddProdut(Product product);

        Task AddProductGallery(ProductGallery productGallery);

        void UpdateProduct(Product product);

        void RemoveProductCategory(List<ProductCategory> productCategories);

        void UpdateProductGallery(ProductGallery productGallery);

        Task SaveChanges();
    }
}
