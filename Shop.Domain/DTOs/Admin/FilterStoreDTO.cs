using Shop.Domain.DTOs.Paging;
using Shop.Domain.Entities.MarketPlaceStore;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.DTOs.Admin
{
    public partial class FilterStoreDTO : BasePaging
    {

        public string? StoreName { get; set; }

        public RequesPanelState RequesPanelState { get; set; }


        public string? PhoneNumber { get; set; }


        public string? MobileNumber { get; set; }

      
        public string? Address { get; set; }

        public string? Code { get; set; }

        public string UserId { get; set; }



        public FilterStoreDTO SetStores(List<Store> stores)
        {
            this.Stores = stores;
            return this;
        }

        public FilterStoreDTO SetPaging(BasePaging paging)
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
    }

    public partial class FilterStoreDTO
    {
        //Filters

        public OrderBy OrderBy { get; set; }

    }

    public partial class FilterStoreDTO
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
