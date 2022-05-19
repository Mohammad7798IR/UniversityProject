using System.ComponentModel.DataAnnotations;



namespace Shop.Domain.DTOs.Seller.StoreProduct
{
    public class CreateProductDTO
    {
        [Display(Name ="نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ProductName { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string ShortDescription { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public decimal Price { get; set; }

        public List<string> SelectedCategories { get; set; }
    }

    public enum CreateProductResult
    {
        Success,
        Fail,
        HasNoImage
    }
}
