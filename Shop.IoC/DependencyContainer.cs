using MarketPlace.DataLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using SendEmail;
using Shop.Application.Interfaces;
using Shop.Application.Interfaces.Admin;
using Shop.Application.Interfaces.Seller;
using Shop.Application.Services;
using Shop.Application.Services.Admin;
using Shop.Application.Services.Seller;
using Shop.Data.Repositories;
using Shop.Data.Repositories.Admin;
using Shop.Data.Repositories.Seller;
using Shop.Domain.Interfaces;
using Shop.Domain.Interfaces.Admin;
using Shop.Domain.Interfaces.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.IoC
{
    public static class DependencyContainer
    {
        public static void ReisterService(IServiceCollection services)
        {
            #region Tools

            services.AddScoped<IViewRenderService, RenderViewToString>();
          

            #endregion



            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ISiteRepository, SiteRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion


            #region Services

            services.AddScoped<IUserservice, UserService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ISiteService, SiteService>();
            services.AddSingleton<IChatService, ChatService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IProductService, ProductService>();
            #endregion
        }
    }
}
