using Shop.Domain.Entities.MarketPlaceStore;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Interfaces.Admin
{
    public partial interface IAdminRepository
    {
        Task<Store> FindStoreById(string id);

        Task<Store> FindStoreAndUserByStoreId(string id);


        Task<Product> FindProductByProductId(string productId);
    }



    public partial interface IAdminRepository
    {

        Task SaveChanges();

        void UpdateStore(Store store);

        void UpdateProduct(Product product);   
    }
}
