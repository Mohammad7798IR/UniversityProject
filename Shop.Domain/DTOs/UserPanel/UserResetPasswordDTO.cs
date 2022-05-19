using Shop.Domain.DTOs.Common;
using System.ComponentModel.DataAnnotations;



namespace Shop.Domain.DTOs.UserPanel
{
    public class UserResetPasswordDTO : ReCaptchaDTO
    {
        [Display(Name = " رمز عبور فعلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string CurrentPassword { get; set; }


        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Compare("Password", ErrorMessage = "کلمه ی عبور با هم مغایرت دارند")]
        public string ConfirmPassword { get; set; }
    }
    public enum UserResetPasswordResult
    {
        WrongCurrentPassword,
        success,
        fail,
        NotFound
    }
}
