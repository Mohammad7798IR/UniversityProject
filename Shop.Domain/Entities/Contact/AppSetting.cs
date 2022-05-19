using System.ComponentModel.DataAnnotations;



namespace Shop.Domain.Entities.Contact
{
    public class AppSetting : BaseEntity
    {
        [Key]
        public string Id { get; set; }

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
