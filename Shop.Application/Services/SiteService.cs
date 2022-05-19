using Shop.Application.Interfaces;
using Shop.Domain.Entities.Site;
using Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public partial class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;

        public SiteService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }
    }
    public partial class SiteService 
    {
        public async Task<List<Slider>> GetAllActiveSliders()
        {
            return await _siteRepository.GetAllActiveSliders();
        }
    }
}
