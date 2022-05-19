using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace Shop.Domain.DTOs.Seller.StoreProduct
{
    public class CreateProductGalleryDTO
    {
        [Display(Name = "اولویت نمایش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int DisplayPriority { get; set; }


    }

    public enum CreateProductGalleryResult
    {
        success , 
        failure ,
        HasNoImage,
        InvalidStore
    }
}
