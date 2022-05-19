using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Domain.DTOs.Paging;
using Shop.Domain.Entities.MarketPlaceStore;
using Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public partial class StoreRepository : IStoreRepository
    {
        private readonly MollaShopDBContext _context;

        public StoreRepository(MollaShopDBContext context)
        {
            _context = context;
        }


    }
    public partial class StoreRepository
    {
        public async Task<List<Store>> Paging(BasePaging basePaging, string userId)
        {
            return await _context.Store.Include(u => u.User).Where(u => u.UserId == userId).AsQueryable()
                 .Skip(basePaging.SkipEntity).Take(basePaging.TakeEntity).ToListAsync();
        }
    }
}
