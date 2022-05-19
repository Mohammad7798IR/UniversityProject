using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Domain.Entities.MarketPlaceStore;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using Shop.Domain.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories.Admin
{
    public partial class AdminRepository : IAdminRepository
    {
        private readonly MollaShopDBContext _context;

        public AdminRepository(MollaShopDBContext context)
        {
            _context = context;
        }
      
    }


    #region Store

    public partial class AdminRepository
    {
        public async Task<Store> FindStoreById(string id)
        {
            return await _context.Store.AsQueryable()
                .Where(s => s.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Store> FindStoreAndUserByStoreId(string id)
        {
            return await _context.Store.AsQueryable()
                .Where(x => x.Id == id).Include(x => x.User).SingleOrDefaultAsync();
        }
    }


    #endregion




    #region Product


    public partial class AdminRepository
    {
        public async Task<Product> FindProductByProductId(string productId)
        {
            return await _context.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
        }
    }


    #endregion



    public partial class AdminRepository
    {
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateStore(Store store)
        {
            _context.Store.Update(store);
        }


        public void UpdateProduct(Product product)
        {
           _context.Products.Update(product);
        }
    }
}
