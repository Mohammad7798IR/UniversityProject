using Microsoft.AspNetCore.Http;
using Shop.Domain.DTOs.Seller.StoreProduct;
using Shop.Domain.Entities.MarketPlaceStore.Products;


namespace Shop.Application.Interfaces.Seller
{
    public partial interface ISellerService
    {
        Task<CreateProductResult> CreateProduct(IFormFile postedFile, CreateProductDTO createProductDTO, string storeId);

        Task<FilterSellerProductDTO> FilterProduct(FilterSellerProductDTO filterProductDTO, string storeId);

        Task<DeleteProductDTO> DeleteProduct(string productId);

        Task<EditProductDTO> GetInfoEditProduct(string productId);

        Task<EditProductResult> EditProduct(EditProductDTO editProductDTO, string userId, string productId, IFormFile postedFile);

        Task<Product> GetProductByOwnerIdAndProductId(string productId, string userId);
    }

    public partial interface ISellerService
    {
        Task<List<ProductGallery>> GetAllProductGalleriesByProductId(string productId);

        Task<List<ProductGallery>> GetAllProductGalleriesInStorePanelByProductId(string productId, string userId);

        Task<CreateProductGalleryResult> CreateProductGallery(CreateProductGalleryDTO createProductGalleryDTO, IFormFile productImage, string productId, string userId);

        Task<ProductGallery> GetProductGalleryForEdit(string productGalleryId, string userId);

        Task<CreateProductGalleryResult> EditProductGallery(CreateProductGalleryDTO createProductGalleryDTO, string productGalleryId, string userId, IFormFile productImage);
    }



    public partial interface ISellerService
    {
        Task<List<Category>> GetAllCategories();
    }
}
