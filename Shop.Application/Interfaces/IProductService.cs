using Shop.Domain.DTOs.Common.Products;


namespace Shop.Application.Interfaces
{
    public partial interface IProductService
    {
        Task<FilterProductsDTO> FilterProducts(FilterProductsDTO filterProductsDTO);

        Task<ProductDetailsDTO> ProductDetails(string productId);

    }
}
