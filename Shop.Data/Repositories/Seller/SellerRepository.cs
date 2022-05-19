using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using Shop.Domain.Interfaces.Seller;


namespace Shop.Data.Repositories.Seller
{
    public partial class SellerRepository : ISellerRepository
    {
        private readonly MollaShopDBContext _context;

        public SellerRepository(MollaShopDBContext context)
        {
            _context = context;
        }

     
    }
    public partial class SellerRepository
    {
        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.Where(x => !x.IsDeleted).ToListAsync();
        }
    }


    public partial class SellerRepository
    {
        public async Task AddProductCategory(List<ProductCategory> productCategory)
        {
            foreach (var item in productCategory)
            {
                _context.ProductCategories.AddAsync(item);
            }
        }


        public async Task<Product> FindProductById(string productId)
        {
            return await _context.Products.AsQueryable()
                 .Where(x => x.Id == productId).SingleOrDefaultAsync();
        }

        public async Task<Product> FindProductAndProductCategoriesById(string productId)
        {
            return await _context.Products.Include(x => x.productCategories)
                .Where(x => x.Id == productId).SingleOrDefaultAsync();
        }

        public async Task<List<ProductCategory>> FindProductCategoriesByProductId(string productId)
        {
            return await _context.ProductCategories.AsQueryable()
                .Where(p => p.ProductId == productId).ToListAsync();
        }

    }


    public partial class SellerRepository
    {
        public async Task<List<ProductGallery>> GetAllProductGalleriesByProductId(string productId)
        {
            return await _context.ProductGalleries.AsQueryable()
                 .Where(x => x.ProductId == productId).ToListAsync();
        }


        public async Task<List<ProductGallery>> GetAllProductGalleriesForStoreByProductId(string productId, string userId)
        {
            return await _context.ProductGalleries
                .Include(x => x.Product)
                .Where(y => y.Id == productId && y.Product.StoreId == userId).ToListAsync();
        }


        public async Task<Product> GetProductByProductIdAndOwnerId(string productId, string userId)
        {
            return await _context.Products
                 .Include(x => x.Store)
                 .Where(p => p.Id == productId && p.Store.UserId == userId).SingleOrDefaultAsync();
        }


        public async Task<ProductGallery> GetProductGalleryByProductGalleryId(string productGalleryId, string userId)
        {
            return await _context.ProductGalleries
                .Include(p => p.Product).ThenInclude(s => s.Store)
                .Where(x => x.Id == productGalleryId && x.Product.Store.UserId == userId).SingleOrDefaultAsync();
        }
    }




    public partial class SellerRepository
    {
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public void RemoveProductCategory(List<ProductCategory> productCategories)
        {
            _context.RemoveRange(productCategories);
        }

        public void UpdateProductGallery(ProductGallery productGallery)
        {
            _context.ProductGalleries.UpdateRange(productGallery);
        }


        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddProdut(Product product)
        {
            await _context.Products.AddAsync(product);
        }


        public async Task AddProductGallery(ProductGallery productGallery)
        {
            await _context.ProductGalleries.AddAsync(productGallery);
        }


    }
}
