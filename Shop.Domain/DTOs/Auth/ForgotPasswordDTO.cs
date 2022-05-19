using Shop.Domain.DTOs.Common;
using System.ComponentModel.DataAnnotations;



namespace Shop.Domain.DTOs.Auth
{
    public class ForgotPasswordDTO : ReCaptchaDTO
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "فیلد ایمیل الزامی می باشد")]
        [DataType(DataType.EmailAddress, ErrorMessage = "فرمت ایمیل وارده صحیح نمی باشد")]
        public string Email { get; set; }
    }
    public enum ForgotPasswordResult
    {
        Success,
        NotFound,
        InActive,
        Fail
    }
}
