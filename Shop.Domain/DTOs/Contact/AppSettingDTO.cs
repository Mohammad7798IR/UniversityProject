using System.ComponentModel.DataAnnotations;



namespace Shop.Domain.DTOs.Contact
{
    public class AppSettingDTO
    {

        [Required]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }
    }
}
