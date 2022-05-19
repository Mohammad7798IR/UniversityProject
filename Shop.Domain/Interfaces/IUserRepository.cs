using Shop.Domain.Entities.Identity;
using Shop.Domain.Entities.MarketPlaceStore;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Interfaces
{
    public partial interface IUserRepository
    {
        Task<bool> UserNameExists(string userName);

        Task<bool> EmailExists(string email);

        Task<ApplicationUser> FindUserByActiveCode(string activeCode);

        Task<ApplicationUser> FindUserByEmail(string email);

        Task<ApplicationUser> FindUserById(string id);

        Task<ApplicationUser> FindUserAndRolesByEmail(string email);

        Task<ApplicationUser> FindUserAndRolesById(string id);
    }


    //UserPanel
    public partial interface IUserRepository
    {
        Task<List<ApplicationUser>> FindUserAndStoresById(string userId);

        Task<List<Store>> FindStoresByUserId(string userId);

        //Task<List<Store>> FindStoresByUserId(string userId);

        Task<Store> GetStoreAndProductsByUserId(string userId);

        Task AddStore(Store newStore);

        Task<Store> GetStoreByUserId(string userId);

        Task<bool> HasUserGotAcceptedStoreByUserId(string userId);
    }

    public partial interface IUserRepository
    {
        Task AddUser(ApplicationUser user);

        void UpdateUser(ApplicationUser user);

        Task AddUserRole(ApplicationUserRole userRole);

        Task SaveChanges();
    }
}
