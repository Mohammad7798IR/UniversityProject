using Shop.Domain.DTOs.Common;
using System.ComponentModel.DataAnnotations;



namespace Shop.Domain.DTOs.Auth
{
    public class ResetPasswordDTO : ReCaptchaDTO
    {
        [Display(Name = "گذرواژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "گذرواژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Compare("Password", ErrorMessage = "کلمه ی عبور با هم مغایرت دارند")]
        public string ConfirmPassword { get; set; }

        public string ActiveCode { get; set; }
    }
   
}
