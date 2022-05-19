using Shop.Domain.DTOs.Admin;
using Shop.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.Admin
{

    #region Stores

    public partial interface IAdminService
    {
        Task<FilterStoreDTO> FilterStores(FilterStoreDTO filterStoreDTO);

        Task<bool> AcceptStore(string storeId);

        Task<bool> RejectStoreRequest(RejectItemDTO rejectItemDTO);

      
    }

    #endregion




    #region Products

    public partial interface IAdminService
    {
        Task<AdminFilterProductsDTO> FilterProducts(AdminFilterProductsDTO filterProductsDTO);


        Task<bool> AcceptProductRequest(string productId);


        Task<bool> RejectProductRequest(RejectItemDTO rejectItemDTO);
    }

    #endregion
}
