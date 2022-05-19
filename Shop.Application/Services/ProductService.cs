using MarketPlace.DataLayer.Repository;
using Shop.Application.Interfaces;
using Shop.Domain.DTOs.Common.Products;
using Shop.Domain.DTOs.Paging;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using Shop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Services
{
    public partial class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Product> _genericRepository;

        public ProductService(IProductRepository productRepository, IGenericRepository<Product> genericRepository)
        {
            _productRepository = productRepository;
            _genericRepository = genericRepository;
        }


    }
    public partial class ProductService
    {
        public async Task<FilterProductsDTO> FilterProducts(FilterProductsDTO filterProductsDTO)
        {
            var query = _genericRepository.GetQuery().AsQueryable().Where(p => p.IsDeleted == false);

            if (filterProductsDTO.IsDeleted)
            {
                query = _genericRepository.GetQuery().AsQueryable();
            }



            if (filterProductsDTO.MaxPrice != 0 || filterProductsDTO.MinPrice != 0)
            {
                query = query.Where(p => p.Price <= filterProductsDTO.MaxPrice && p.Price >= filterProductsDTO.MinPrice);
            }

            switch (filterProductsDTO.OrderBy)
            {
                case ProductOrderBy.MostViewed:
                    query = query.OrderByDescending(p => p.ViewCount);
                    break;
                case ProductOrderBy.MostRecent:
                    query = query.OrderByDescending(p => p.CreatedAt);
                    break;
                case ProductOrderBy.MostSold:
                    query = query.OrderByDescending(p => p.CreatedAt);
                    break;
                case ProductOrderBy.Cheapest:
                    query = query.OrderBy(p => p.Price);
                    break;
                default:
                    break;
            }


            var paging = Pager.Build(filterProductsDTO.PageId, query.Count(), filterProductsDTO.TakeEntity, filterProductsDTO.HowManyShowPageAfterAndBefore);

            var pagedEntities = query.Paging(paging).ToList();

            return filterProductsDTO.SetPaging(paging).SetProducts(pagedEntities);
        }


        public async Task<ProductDetailsDTO> ProductDetails(string productId)
        {
            var product = await _productRepository.GetProductAndProductGalleriesByProductId(productId);

            var productCat = await _productRepository.GetProductAndProductCategoriesByProductId(productId);

            if (product == null)
            {
                var productNotFound = new ProductDetailsDTO()
                {
                    Result = false
                };

                return productNotFound;
            }



            var productDetails = new ProductDetailsDTO()
            {
                Product = product,
                ProductGalleries = product.productGalleries,
                ProductCategories = product.productCategories,
                Result = true,
            };

            return productDetails;
        }
    }
}
