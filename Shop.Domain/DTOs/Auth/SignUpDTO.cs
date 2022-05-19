using Shop.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTOs.Auth
{
    public class SignUpDTO : ReCaptchaDTO
    {

        [Display(Name = " نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "فیلد نام کاربری الزامی می باشد")]
        [DataType(DataType.Text, ErrorMessage = "فرمت نام کاربری وارده صحیح نمی باشد")]
        public string Username { get; set; }

        [Display(Name = "پست الکترونیک")]
        [EmailAddress(ErrorMessage = "فرمت پست الکترونیک صحیح نمی باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Email { get; set; }

        [Display(Name = "گذرواژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "گذرواژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Compare("Password", ErrorMessage = "کلمه ی عبور با هم مغایرت دارند")]
        public string ConfirmPassword { get; set; }
    }
    public enum SginUpResult
    {
        Success,
        EmailExits,
        UserNameExits
    }
}
