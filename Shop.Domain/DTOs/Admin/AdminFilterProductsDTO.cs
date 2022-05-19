using Shop.Domain.DTOs.Paging;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTOs.Admin
{
    public partial class AdminFilterProductsDTO : BasePaging
    {

        public string? ProductName { get; set; }

        public ProductAcceptanceState ProductAcceptanceState { get; set; }


        //public string? ImageName { get; set; }


        //public string? StoreName { get; set; }


        //public string? CreatedAt { get; set; }



        public string UserId { get; set; }

        public List<Product> Products { get; set; }

        public ProductAcceptanceState RequesPrdouctState { get; set; }


        public OrderBy OrderBy { get; set; }

    }

    public partial class AdminFilterProductsDTO
    {
        public AdminFilterProductsDTO SetPrdoucts(List<Product> products)
        {
            this.Products = products;
            return this;
        }

        public AdminFilterProductsDTO SetPaging(BasePaging paging)
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
}
