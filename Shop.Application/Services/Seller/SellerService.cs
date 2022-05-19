using MarketPlace.Application.Extensions;
using MarketPlace.Application.Utils;
using MarketPlace.DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Shop.Application.Extentions;
using Shop.Application.Interfaces.Seller;
using Shop.Application.Utils;
using Shop.Domain.DTOs.Paging;
using Shop.Domain.DTOs.Seller.StoreProduct;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using Shop.Domain.Interfaces;
using Shop.Domain.Interfaces.Seller;


namespace Shop.Application.Services.Seller
{
    public partial class SellerService : ISellerService
    {
        private readonly ISellerRepository _productRepository;
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IUserRepository _userRepository;


        public SellerService
            (
            ISellerRepository productRepository,
            IGenericRepository<Product> genericRepository,
            IUserRepository userRepository
            )
        {
            _productRepository = productRepository;
            _genericRepository = genericRepository;
            _userRepository = userRepository;
        }


    }
    public partial class SellerService
    {

        public async Task<CreateProductResult> CreateProduct(IFormFile postedFile, CreateProductDTO createProductDTO, string storeId)
        {
            if (postedFile == null) return CreateProductResult.HasNoImage;


            if (!postedFile.IsImage()) return CreateProductResult.Fail;

            createProductDTO.Description = TextFixer.StripHTML(createProductDTO.Description);
            createProductDTO.Description = TextFixer.FixText(createProductDTO.Description);
            createProductDTO.Description = createProductDTO.Description.Replace("&nbsp;", " ");
            createProductDTO.Description = createProductDTO.Description.Trim();

            createProductDTO.ShortDescription = TextFixer.StripHTML(createProductDTO.ShortDescription);
            createProductDTO.ShortDescription = createProductDTO.ShortDescription.Replace("&nbsp;", " ");
            createProductDTO.ShortDescription = TextFixer.FixText(createProductDTO.ShortDescription);
            createProductDTO.ShortDescription = createProductDTO.ShortDescription.Trim();


            var imageName = Guid.NewGuid().ToString() + Path.GetExtension(postedFile.FileName);

            postedFile.AddImageToServer(imageName, FilePath.ProductServerOrigin, 100, 100, FilePath.ProductServerThumb);


            var newProduct = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = UserExtention.GetPersianDateTime(DateTime.Now),
                ImageName = imageName,
                Description = createProductDTO.Description,
                ProductAcceptanceState = ProductAcceptanceState.UnderProgress,
                StoreId = storeId,
                ShortDescription = createProductDTO.ShortDescription,
                Price = createProductDTO.Price,
                ProductAcceptOrRejectDescription = "در حال بررسی",
                Title = createProductDTO.ProductName,
                IsActive = true,
                IsDeleted = false,
            };

            await _productRepository.AddProdut(newProduct);

            await _productRepository.SaveChanges();

            var lstCat = new List<ProductCategory>();


            foreach (var item in createProductDTO.SelectedCategories)
            {
                var selectedCat = new ProductCategory()
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = newProduct.Id,
                    CreatedAt = UserExtention.GetPersianDateTime(DateTime.Now),
                    IsDeleted = false,
                    CategoryId = item
                };
                lstCat.Add(selectedCat);
            }

            await _productRepository.AddProductCategory(lstCat);
            await _productRepository.SaveChanges();


            return CreateProductResult.Success;
        }

        public async Task<EditProductDTO> GetInfoEditProduct(string productId)
        {
            var product = await _productRepository.FindProductAndProductCategoriesById(productId);
            var cat = await GetAllCategories();



            EditProductDTO editProductDTO = new EditProductDTO();

            if (product == null)
            {
                editProductDTO.Result = false;
                return editProductDTO;
            }

            editProductDTO.Product = product;
            editProductDTO.Categories = cat;
            editProductDTO.SelectedCategories = product.productCategories.Where(x => x.ProductId == productId && x.IsDeleted == false).Select(s => s.CategoryId).ToList();
            editProductDTO.Result = true;


            editProductDTO.ProductName = product.Title;
            editProductDTO.Price = product.Price;
            editProductDTO.Description = product.Description;
            editProductDTO.ShortDescription = product.ShortDescription;
            editProductDTO.ProductId = product.Id;


            return editProductDTO;
        }

        public async Task<EditProductResult> EditProduct(EditProductDTO editProductDTO, string userId, string productId, IFormFile postedFile)
        {
            var store = await _userRepository.GetStoreAndProductsByUserId(userId);

            if (store == null) return EditProductResult.InvalidStore;

            var product = store.Products.Where(p => p.Id == productId).FirstOrDefault();

            if (postedFile == null) return EditProductResult.NoImage;


            if (!postedFile.IsImage()) return EditProductResult.NotImage;


            var imageName = Guid.NewGuid().ToString() + Path.GetExtension(postedFile.FileName);

            postedFile.AddImageToServer(imageName, FilePath.ProductServerOrigin, 100, 100, null, product.ImageName);

            product.Description = TextFixer.StripHTML(product.Description);
            product.Description = TextFixer.FixText(product.Description);
            product.Description = product.Description.Replace("&nbsp;", " ");
            product.Description = product.Description.Trim();

            product.ShortDescription = TextFixer.StripHTML(product.ShortDescription);
            product.ShortDescription = product.ShortDescription.Replace("&nbsp;", " ");
            product.ShortDescription = TextFixer.FixText(product.ShortDescription);
            product.ShortDescription = product.ShortDescription.Trim();

            product.Title = editProductDTO.ProductName;
            product.Price = editProductDTO.Price;
            product.Description = editProductDTO.Description;
            product.ShortDescription = editProductDTO.ShortDescription;
            product.ImageName = imageName;
            product.UpdatedAt = UserExtention.GetPersianDateTime(DateTime.Now);
            product.ProductAcceptanceState = ProductAcceptanceState.UnderProgress;

            _productRepository.UpdateProduct(product);
            await _productRepository.SaveChanges();


            var productCat = await _productRepository.FindProductCategoriesByProductId(productId);


            _productRepository.RemoveProductCategory(productCat);
            await _productRepository.SaveChanges();


            var lstCat = new List<ProductCategory>();

            foreach (var item in editProductDTO.SelectedCategories)
            {
                var cat = new ProductCategory()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedAt = UserExtention.GetPersianDateTime(DateTime.Now),
                    ProductId = productId,
                    IsDeleted = false,
                    CategoryId = item
                };
                lstCat.Add(cat);
            }


            await _productRepository.AddProductCategory(lstCat);
            await _productRepository.SaveChanges();

            return EditProductResult.Success;
        }

        public async Task<FilterSellerProductDTO> FilterProduct(FilterSellerProductDTO filterProductDTO, string storeId)
        {
            var query = _genericRepository.GetQuery().AsQueryable();

            query = query.Where(x => x.StoreId == storeId && x.IsDeleted == false);

            switch (filterProductDTO.ProductAcceptanceState)
            {

                case ProductAcceptanceState.All:
                    break;

                case ProductAcceptanceState.Accepted:
                    query = query.Where(x => x.ProductAcceptanceState == ProductAcceptanceState.Accepted);
                    break;

                case ProductAcceptanceState.UnderProgress:
                    query = query.Where(x => x.ProductAcceptanceState == ProductAcceptanceState.UnderProgress);
                    break;

                case ProductAcceptanceState.Rejected:
                    query = query.Where(x => x.ProductAcceptanceState == ProductAcceptanceState.Rejected);
                    break;

                default:
                    break;
            }


            switch (filterProductDTO.OrderBy)
            {
                case OrderBy.OrderByAscending:
                    query = query.OrderBy(x => x.CreatedAt);
                    break;

                case OrderBy.OrderByDescending:
                    query = query.OrderByDescending(x => x.CreatedAt);
                    break;

                default:
                    break;
            }


            var paging = Pager.Build(filterProductDTO.PageId, query.Count(), filterProductDTO.TakeEntity, filterProductDTO.HowManyShowPageAfterAndBefore);

            var pagedEntities = query.Paging(paging).ToList();

            return filterProductDTO.SetPaging(paging).SetProducts(pagedEntities);
        }

        public async Task<DeleteProductDTO> DeleteProduct(string productId)
        {
            var deleteProductDto = new DeleteProductDTO();

            var product = await _productRepository.FindProductById(productId);

            if (product == null)
            {
                deleteProductDto.Result = false;
                return deleteProductDto;
            }

            product.IsDeleted = true;

            _productRepository.UpdateProduct(product);

            await _productRepository.SaveChanges();

            deleteProductDto.Product = product;
            deleteProductDto.Result = true;

            return deleteProductDto;

        }
    }



    public partial class SellerService
    {
        public async Task<List<ProductGallery>> GetAllProductGalleriesByProductId(string productId)
        {
            return await _productRepository.GetAllProductGalleriesByProductId(productId);
        }

        public async Task<List<ProductGallery>> GetAllProductGalleriesInStorePanelByProductId(string productId, string userId)
        {
            return await _productRepository.GetAllProductGalleriesForStoreByProductId(productId, userId);
        }

        public async Task<Product> GetProductByOwnerIdAndProductId(string productId, string userId)
        {
            return await _productRepository.GetProductByProductIdAndOwnerId(productId, userId);
        }


        public async Task<CreateProductGalleryResult> CreateProductGallery(CreateProductGalleryDTO createProductGalleryDTO
            , IFormFile productImage, string productId, string userId)
        {

            if (productImage == null) return CreateProductGalleryResult.HasNoImage;


            if (!productImage.IsImage()) return CreateProductGalleryResult.failure;

            var product = await _productRepository.GetProductByProductIdAndOwnerId(productId, userId);

            if (product == null) return CreateProductGalleryResult.InvalidStore;

            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(productImage.FileName);

            productImage.AddImageToServer(imageName, FilePath.ProductGalleryImageServer, 100, 100);


            ProductGallery newGallery = new ProductGallery()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = UserExtention.GetPersianDateTime(DateTime.Now),
                DisplayPriority = createProductGalleryDTO.DisplayPriority,
                ImageName = imageName,
                ProductId = productId,
                IsDeleted = false,
            };

            await _productRepository.AddProductGallery(newGallery);
            await _productRepository.SaveChanges();


            return CreateProductGalleryResult.success;
        }


        public async Task<ProductGallery> GetProductGalleryForEdit(string productGalleryId, string userId)
        {
            var productGallery = await _productRepository.GetProductGalleryByProductGalleryId(productGalleryId, userId);


            if (productGallery == null) return null;


            return productGallery;

        }


        public async Task<CreateProductGalleryResult> EditProductGallery(CreateProductGalleryDTO createProductGalleryDTO, string productGalleryId, string userId, IFormFile productImage)
        {
            var productGalley = await _productRepository.GetProductGalleryByProductGalleryId(productGalleryId, userId);

            if (productGalley == null) return CreateProductGalleryResult.InvalidStore;

            if (productImage == null) return CreateProductGalleryResult.HasNoImage;

            if (!productImage.IsImage()) return CreateProductGalleryResult.InvalidStore;

            var imageName = Guid.NewGuid().ToString() + Path.GetExtension(productImage.FileName);

            productImage.AddImageToServer(imageName, FilePath.ProductGalleryImageServer, 100, 100, null, productGalley.ImageName);


            productGalley.UpdatedAt = UserExtention.GetPersianDateTime(DateTime.Now);
            productGalley.ImageName = imageName;
            productGalley.DisplayPriority = createProductGalleryDTO.DisplayPriority;

            _productRepository.UpdateProductGallery(productGalley);

            await _productRepository.SaveChanges();

            return CreateProductGalleryResult.success;
        }
    }

    public partial class SellerService
    {
        public async Task<List<Category>> GetAllCategories()
        {
            return await _productRepository.GetAllCategories();
        }
    }
}
