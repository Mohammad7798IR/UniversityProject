using Microsoft.AspNetCore.Identity;
using Shop.Domain.Entities.Chat;
using Shop.Domain.Entities.Contact;
using Shop.Domain.Entities.MarketPlaceStore;
using Shop.Domain.Entities.MarketPlaceStore.Products;
using System.ComponentModel.DataAnnotations;


namespace Shop.Domain.Entities.Identity
{
    public partial class ApplicationUser : IdentityUser<string>
    {

        [Required]
        [Display(Name = "تاریخ عضویت")]
        public string CreatedAt { get; set; }

        [Display(Name = "تاریخ تغییر")]
        public string? UpdatedAt { get; set; }

        [Display(Name = "تاریخ تولد")]
        public string? BirthDate { get; set; }

        [MaxLength(250)]
        [Display(Name = "نام")]
        public string? FirstName { get; set; }

        [MaxLength(250)]
        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "جنسیت")]
        public Gender Gender { get; set; }

        [Display(Name = "تصویر آواتار")]
        public string? Avatar { get; set; }

        [Display(Name = "کد فعال سازی")]
        public string? ActiveCode { get; set; }
    }


    #region Relations

    public partial class ApplicationUser
    {
        public ICollection<ApplicationUserRole> userRoles { get; set; } = new HashSet<ApplicationUserRole>();

        public ICollection<ContactUs> ContactUs { get; set; } = new HashSet<ContactUs>();

        public ICollection<ChatMessage> ChatMessages { get; set; } = new HashSet<ChatMessage>();

        public ICollection<Store> Stores { get; set; } = new HashSet<Store>();

        //public ICollection<UserChatGroup> UserChatGroups { get; set; } = new HashSet<UserChatGroup>();
    }

    #endregion


    public enum Gender
    {
        [Display(Name = "اقا")]
        Male,
        [Display(Name = "خانوم")]
        Female,
        [Display(Name = "نامشخص")]
        Unknown
    }

}
