using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Domain.Entities.Site;
using Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public partial class SiteRepository : ISiteRepository
    {
        private readonly MollaShopDBContext _context;

        public SiteRepository(MollaShopDBContext context)
        {
            _context = context;
        }
    }
    public partial class SiteRepository
    {
        public async Task<List<Slider>> GetAllActiveSliders()
        {
            return await _context.Slider.Where(a => a.IsActive && a.IsDeleted == false).ToListAsync();
        }
    }
}
