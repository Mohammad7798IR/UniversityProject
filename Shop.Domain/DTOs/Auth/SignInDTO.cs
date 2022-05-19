using Shop.Domain.DTOs.Common;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.DTOs.Auth
{
    public class SignInDTO : ReCaptchaDTO
    {

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "فیلد ایمیل الزامی می باشد")]
        [DataType(DataType.EmailAddress, ErrorMessage = "فرمت ایمیل وارده صحیح نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "گذرواژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Password { get; set; }


        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
    public enum SignInResult
    {
        Success,
        NotFound,
        Blocked,
        InActive
    }
}