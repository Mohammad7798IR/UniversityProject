using MarketPlace.DataLayer.Repository;
using Microsoft.Extensions.Configuration;
using SendEmail;
using Shop.Application.Extentions;
using Shop.Application.Interfaces.Admin;
using Shop.Domain.DTOs.Admin;
using Shop.Domain.DTOs.Common;
using Shop.Domain.DTOs.Paging;
using Shop.Domain.Entities.Identity;
using Shop.Domain.Entities.MarketPlaceStore;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using Shop.Domain.Interfaces;
using Shop.Domain.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Admin
{
    public partial class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IGenericRepository<Store> _storeGenericRepository;
        private readonly IGenericRepository<Product> _productGenericRepository;
        private readonly IViewRenderService _viewRenderService;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AdminService
            (
            IAdminRepository adminRepository,
            IGenericRepository<Store> storeGenericRepository,
            IViewRenderService viewRenderService,
            IConfiguration configuration,
            IUserRepository userRepository,
            IGenericRepository<Product> productGenericRepository
            )
        {
            _adminRepository = adminRepository;
            _storeGenericRepository = storeGenericRepository;
            _viewRenderService = viewRenderService;
            _configuration = configuration;
            _userRepository = userRepository;
            _productGenericRepository = productGenericRepository;
        }

    }


    #region Stores

    public partial class AdminService
    {
        public async Task<FilterStoreDTO> FilterStores(FilterStoreDTO filterStoreDTO)
        {
            var query = _storeGenericRepository.GetQuery().AsQueryable();


            query = query.Where(a => a.IsDeleted == false);

            foreach (var item in query)
            {
                switch (filterStoreDTO.RequesPanelState)
                {
                    case RequesPanelState.All:
                        break;
                    case RequesPanelState.Accepted:
                        query = query.Where(a => a.StoreAcceptanceState == StoreAcceptanceState.Accepted);
                        break;
                    case RequesPanelState.Rejected:
                        query = query.Where(a => a.StoreAcceptanceState == StoreAcceptanceState.Rejected);
                        break;
                    case RequesPanelState.UnderProgress:
                        query = query.Where(a => a.StoreAcceptanceState == StoreAcceptanceState.UnderProgress);
                        break;
                    default:
                        break;
                }


                switch (filterStoreDTO.OrderBy)
                {
                    case OrderBy.Order_DEC:
                        query = query.OrderByDescending(a => a.CreatedAt);
                        break;
                    case OrderBy.Order_ACE:
                        query = query.OrderBy(a => a.CreatedAt);
                        break;
                    default:
                        break;
                }

            }
            if (!string.IsNullOrEmpty(filterStoreDTO.StoreName))
            {
                query = query.Where(a => a.StoreName.EndsWith(filterStoreDTO.StoreName)
                || a.StoreName.Contains(filterStoreDTO.StoreName)
                || a.StoreName.StartsWith(filterStoreDTO.StoreName));
            }

            if (!string.IsNullOrEmpty(filterStoreDTO.MobileNumber))
            {
                query = query.Where(a => a.Mobile.EndsWith(filterStoreDTO.MobileNumber)
                || a.Mobile.Contains(filterStoreDTO.MobileNumber)
                || a.Mobile.StartsWith(filterStoreDTO.MobileNumber));
            }

            if (!string.IsNullOrEmpty(filterStoreDTO.PhoneNumber))
            {
                query = query.Where(a => a.Phone.EndsWith(filterStoreDTO.PhoneNumber)
                || a.Phone.Contains(filterStoreDTO.PhoneNumber)
                || a.Phone.StartsWith(filterStoreDTO.PhoneNumber));
            }


            if (!string.IsNullOrEmpty(filterStoreDTO.Address))
            {
                query = query.Where(a => a.Address.EndsWith(filterStoreDTO.Address)
                || a.Address.Contains(filterStoreDTO.Address)
                || a.Address.StartsWith(filterStoreDTO.Address));
            }


            filterStoreDTO.Stores = query.ToList();

            var pager = Pager.Build(filterStoreDTO.PageId, query.Count(), filterStoreDTO.TakeEntity, filterStoreDTO.HowManyShowPageAfterAndBefore);

            var allEntities = query.Paging(pager).ToList();

            return filterStoreDTO.SetPaging(pager).SetStores(allEntities);

        }


        public async Task<bool> AcceptStore(string storeId)
        {
            var store = await _adminRepository.FindStoreById(storeId);


            if (store == null) return false;


            ApplicationUserRole userRole = new ApplicationUserRole();

            userRole.RoleId = _configuration.GetSection("Roles")["AplicationSeller"];
            userRole.UserId = store.UserId;
            userRole.Id = Guid.NewGuid().ToString();

            store.StoreAcceptanceState = StoreAcceptanceState.Accepted;
            store.StoreAcceptanceDescription = "تایید شده ";

            await _userRepository.AddUserRole(userRole);
            await _userRepository.SaveChanges();


            _adminRepository.UpdateStore(store);
            await _adminRepository.SaveChanges();


            return true;

        }


        public async Task<bool> RejectStoreRequest(RejectItemDTO rejectItemDTO)
        {
            var store = await _adminRepository.FindStoreAndUserByStoreId(rejectItemDTO.Id);

            if (store == null) return false;

            EmailSender emailSender = new EmailSender(_configuration);

            store.UpdatedAt = UserExtention.GetPersianDateTime(DateTime.Now);
            store.StoreAcceptanceState = StoreAcceptanceState.Rejected;
            store.StoreAcceptanceDescription = rejectItemDTO.Description;


            string templte = _viewRenderService.RenderToStringAsync("_RejectItemEmailTemplate", store);

            await emailSender.SendEmail(store.User.Email, "پیگیری درخواست فروشگاه", templte);

            _adminRepository.UpdateStore(store);

            await _adminRepository.SaveChanges();

            return true;
        }
    }

    #endregion


    #region Products

    public partial class AdminService
    {
        public async Task<AdminFilterProductsDTO> FilterProducts(AdminFilterProductsDTO filterProductsDTO)
        {
            var query = _productGenericRepository.GetQuery().AsQueryable();

            query = query.Where(x => x.IsDeleted == false);

            switch (filterProductsDTO.ProductAcceptanceState)
            {
                case ProductAcceptanceState.All:
                    break;

                case ProductAcceptanceState.UnderProgress:

                    query = query.Where(x => x.ProductAcceptanceState == ProductAcceptanceState.UnderProgress);
                    break;

                case ProductAcceptanceState.Accepted:

                    query = query.Where(x => x.ProductAcceptanceState == ProductAcceptanceState.Accepted);
                    break;

                case ProductAcceptanceState.Rejected:

                    query = query.Where(x => x.ProductAcceptanceState == ProductAcceptanceState.Rejected);
                    break;

                default:
                    break;
            }

            switch (filterProductsDTO.OrderBy)
            {
                case OrderBy.Order_DEC:
                    query = query.OrderBy(x => x.CreatedAt);
                    break;
                case OrderBy.Order_ACE:
                    query = query.OrderByDescending(x => x.CreatedAt);
                    break;
                default:
                    break;
            }


            if (!string.IsNullOrEmpty(filterProductsDTO.ProductName))
            {
                query = query.Where(a => a.Title.EndsWith(filterProductsDTO.ProductName)
                || a.Title.Contains(filterProductsDTO.ProductName)
                || a.Title.StartsWith(filterProductsDTO.ProductName));
            }



            filterProductsDTO.Products = query.ToList();


            var pager = Pager.Build(filterProductsDTO.PageId, query.Count(), filterProductsDTO.TakeEntity, filterProductsDTO.HowManyShowPageAfterAndBefore);

            var entities = query.Paging(pager).ToList();

            return filterProductsDTO.SetPaging(pager).SetPrdoucts(entities);

        }


        public async Task<bool> AcceptProductRequest(string productId)
        {
            var product = await _adminRepository.FindProductByProductId(productId);

            if (product == null) return false;


            product.ProductAcceptanceState = ProductAcceptanceState.Accepted;
            product.UpdatedAt = UserExtention.GetPersianDateTime(DateTime.Now);
            product.ProductAcceptOrRejectDescription = "قبول شده است";


            _adminRepository.UpdateProduct(product);
            await _adminRepository.SaveChanges();


            return true;

        }




        public async Task<bool> RejectProductRequest(RejectItemDTO rejectItemDTO)
        {
            var product = await _adminRepository.FindProductByProductId(rejectItemDTO.Id);

            if (product == null) return false;



            product.ProductAcceptOrRejectDescription = rejectItemDTO.Description;
            product.ProductAcceptanceState = ProductAcceptanceState.Rejected;
            product.UpdatedAt = UserExtention.GetPersianDateTime(DateTime.Now);


            _adminRepository.UpdateProduct(product);

            await _adminRepository.SaveChanges();



            return true;
        }
    }

    #endregion
}
