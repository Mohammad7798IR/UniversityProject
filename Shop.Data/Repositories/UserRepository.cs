using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Domain.Entities.Identity;
using Shop.Domain.Entities.MarketPlaceStore;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public partial class UserRepository : IUserRepository
    {
        private readonly MollaShopDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(MollaShopDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

    
    }
    public partial class UserRepository
    {
        public async Task<ApplicationUser> FindUserByActiveCode(string activeCode)
        {
            return await _context.Users
                .Where(u => u.ActiveCode == activeCode).SingleOrDefaultAsync();
        }

        public async Task<ApplicationUser> FindUserAndRolesByEmail(string email)
        {
            return await _context.Users.Include(ur => ur.userRoles).Where(a => a.Email == email).SingleOrDefaultAsync();
        }

        public async Task<ApplicationUser> FindUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> FindUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<bool> UserNameExists(string userName)
        {
            return await _context.Users.AnyAsync(un => un.UserName == userName);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.Users.AnyAsync(un => un.Email == email);
        }

        public async Task<ApplicationUser> FindUserAndRolesById(string id)
        {
            return await _context.Users.Include(ur => ur.userRoles)
                 .Where(x => x.Id == id).SingleOrDefaultAsync();
        }


        public async Task<List<Store>> FindStoresByUserId(string userId)
        {
            return await _context.Store
                .AsQueryable().
                Where(u => u.UserId == userId)
                 .ToListAsync();
        }


    
    }

    //UserPanel
    public partial class UserRepository
    {
        public async Task AddStore(Store newStore)
        {
            await _context.Store.AddAsync(newStore);
        }

        public async Task<Store> GetStoreByUserId(string userId)
        {
            return await _context.Store
                .Where(x => x.UserId == userId && x.StoreAcceptanceState == StoreAcceptanceState.Accepted).Include(x => x.User).FirstOrDefaultAsync();
        }

        public async Task<Store> GetStoreAndProductsByUserId(string userId)
        {
            return await _context.Store.AsQueryable()
                .Include(p => p.Products).Where(u => u.UserId == userId).FirstOrDefaultAsync();

        }


        public async Task<bool> HasUserGotAcceptedStoreByUserId(string userId)
        {
            return await _context.Store.AnyAsync(x => x.UserId == userId && x.StoreAcceptanceState == StoreAcceptanceState.Accepted);
        }


        public async Task<List<ApplicationUser>> FindUserAndStoresById(string userId)
        {
            return await _context.Users.Include(s => s.Stores)
                .Where(a => a.Id == userId).ToListAsync();
        }
    }

    public partial class UserRepository
    {
        public async Task AddUser(ApplicationUser user)
        {
            await _userManager.CreateAsync(user);
        }

        public async Task AddUserRole(ApplicationUserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
        }

        public void UpdateUser(ApplicationUser user)
        {
            _context.Users.Update(user);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
