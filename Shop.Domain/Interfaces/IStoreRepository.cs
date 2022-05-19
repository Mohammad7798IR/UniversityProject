using Shop.Domain.DTOs.Paging;
using Shop.Domain.Entities.MarketPlaceStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Interfaces
{
    public partial interface IStoreRepository
    {
        Task<List<Store>> Paging(BasePaging basePaging, string userId);
    }
}
