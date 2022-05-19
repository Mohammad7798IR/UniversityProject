using System.ComponentModel.DataAnnotations;



namespace Shop.Domain.Entities.MarketPlaceStore.Products
{
    public partial class ProductGallery : BaseEntity
    {
        [Display(Name = "نام تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string ImageName { get; set; }


        public int DisplayPriority { get; set; }
    }

    public partial class ProductGallery
    {
        public Product Product { get; set; }


        public string ProductId { get; set; }
    }
}
