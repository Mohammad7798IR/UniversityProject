using Shop.Domain.DTOs.Paging;
using Shop.Domain.Entities.MarketPlaceStore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTOs.UserPanel
{
    public partial class UserStoreFilterDTO : BasePaging
    {
        public string StoreName { get; set; }

        public StoreAcceptanceState StoreAcceptanceState { get; set; }

        public string PhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string Address { get; set; }

        public string Code { get; set; }

        public string UserId { get; set; }





        #region methods

        public UserStoreFilterDTO SetStores(List<Store> stores)
        {
            this.Stores = stores;
            return this;
        }

        public UserStoreFilterDTO SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
            this.TakeEntity = paging.TakeEntity;
            this.SkipEntity = paging.SkipEntity;
            this.PageCount = paging.PageCount;
            return this;
        }

        #endregion

    }

    public partial class UserStoreFilterDTO
    {
        //Filters

        public OrderBy OrderBy { get; set; }

    }

    public partial class UserStoreFilterDTO
    {
        //Relations
        public List<Store> Stores { get; set; }
    }

    public enum RequesPanelState
    {
        [Display(Name = "همه")]
        All,
        [Display(Name = "در حال بررسی")]
        UnderProgress,
        [Display(Name = "تایید شده")]
        Accepted,
        [Display(Name = "رد شده")]
        Rejected
    }

    public enum OrderBy
    {
        [Display(Name = "جدید ترین")]
        Order_DEC,
        [Display(Name = "قدیمی ترین")]
        Order_ACE
    }

}

