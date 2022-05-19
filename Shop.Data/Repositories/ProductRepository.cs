using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public partial class ProductRepository : IProductRepository
    {
        private readonly MollaShopDBContext _context;

        public ProductRepository(MollaShopDBContext context)
        {
            _context = context;
        }


    }
    public partial class ProductRepository
    {
        public async Task<Product> GetProductAndProductGalleriesByProductId(string productId)
        {
            return await _context.Products.Include(x => x.productGalleries).Where(x => x.Id == productId).FirstOrDefaultAsync();
        }


        public async Task<Product> GetProductAndProductCategoriesByProductId(string productId)
        {
            return await _context.Products.Include(x => x.productCategories).Where(x => x.Id == productId).FirstOrDefaultAsync();
        }
    }
}
