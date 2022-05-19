using Shop.Domain.DTOs.Paging;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTOs.Common.Products
{
    public partial class FilterProductsDTO : BasePaging
    {
        public ICollection<Product> Products { get; set; }

        public ProductOrderBy OrderBy { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public decimal MaxPrice { get; set; }

        [Required]
        public decimal MinPrice { get; set; }

    }

    public partial class FilterProductsDTO
    {
        public FilterProductsDTO SetProducts(List<Product> products)
        {
            this.Products = products;
            return this;
        }

        public FilterProductsDTO SetPaging(BasePaging paging)
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

    public enum ProductOrderBy
    {
        [Display(Name ="پر بازدید ترین")]
        MostViewed,
        [Display(Name = "تازه ترین")]
        MostRecent,
        [Display(Name = "پرفروش ترین")]
        MostSold,
        [Display(Name = "ارزان ترین")]
        Cheapest
    }
}
