using Shop.Domain.DTOs.Paging;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using System.ComponentModel.DataAnnotations;


namespace Shop.Domain.DTOs.Seller.StoreProduct
{
    public partial class FilterSellerProductDTO : BasePaging
    {
        //[Display(Name = "نام محصول")]
        //public string ProductImage { get; set; }

        //[Display(Name = "تصویر محصول")]
        //public string ProductName { get; set; }

        //[Display(Name = "قیمت محصول")]
        //public decimal Price { get; set; }

        //[Display(Name = "توضیحات کوتاه")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        //public string ShortDescription { get; set; }

        //[Display(Name = "توضیحات اصلی")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //public string Description { get; set; }

        [Display(Name = "وضعیت")]
        public ProductAcceptanceState ProductAcceptanceState { get; set; }

        public OrderBy OrderBy { get; set; }

    }

    public partial class FilterSellerProductDTO
    {
        public List<Product> Products { get; set; }
    }

    public enum OrderBy
    {
        OrderByAscending,
        OrderByDescending
    }

    #region methods

    public partial class FilterSellerProductDTO
    {


        public FilterSellerProductDTO SetProducts(List<Product> products)
        {
            this.Products = products;
            return this;
        }

        public FilterSellerProductDTO SetPaging(BasePaging paging)
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

    #endregion


}
