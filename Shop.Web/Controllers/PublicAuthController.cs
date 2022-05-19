using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces;
using Shop.Domain.DTOs.Auth;
using System.Security.Claims;

namespace Shop.Web.Controllers
{
    public partial class PublicAuthController : SiteBaseController
    {
        private readonly IUserservice _userservice;
        private readonly ICaptchaValidator _captchaValidator;
        private readonly IConfiguration _configuration;
        public PublicAuthController(IUserservice userservice, ICaptchaValidator captchaValidator, IConfiguration configuration)
        {
            _userservice = userservice;
            _captchaValidator = captchaValidator;
            _configuration = configuration;
        }
    }
    public partial class PublicAuthController
    {
        #region SignUp

        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("SignUp")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpDTO signUpDTO)
        {
            if (ModelState.IsValid)
            {
                if (await _captchaValidator.IsCaptchaPassedAsync(signUpDTO.Token))
                {
                    var result = await _userservice.SginUp(signUpDTO);
                    switch (result)
                    {
                        case SginUpResult.Success:
                            TempData[SuccessMessage] = "ثبت نام شما با موفقیت انجام شد ";
                            TempData[InfoMessage] = "پست الکترونیک فعال سازی برای شما ارسال شد";
                            return Redirect("/");

                        case SginUpResult.UserNameExits:
                            TempData[ErrorMessage] = "نام کاربری قبلا انتخاب شده است";
                            return View(signUpDTO);

                        case SginUpResult.EmailExits:
                            TempData[ErrorMessage] = "پست الکترونیک قبلا ثبت شده است";
                            return View(signUpDTO);

                        default:
                            break;
                    }
                }
                TempData[ErrorMessage] = "اعتبار سنجی انجام نشد";
                return View(signUpDTO);
            }

            return View(signUpDTO);
        }

        #endregion

        #region SignIn

        [Route("SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }



        [Route("SignIn")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInDTO signInDTO)
        {
            if (ModelState.IsValid)
            {
                if (await _captchaValidator.IsCaptchaPassedAsync(signInDTO.Token))
                {
                    var result = await _userservice.SginIn(signInDTO);
                    switch (result)
                    {
                        case Domain.DTOs.Auth.SignInResult.Success:

                            var user = await _userservice.FindUserAndRolesByEmail(signInDTO.Email);

                            List<Claim> claims = new List<Claim>()
                            {
                              new Claim(ClaimTypes.NameIdentifier ,user.Id.ToString()),
                              new Claim(ClaimTypes.Name , user.Email),
                             };
                            foreach (var item in user.userRoles)
                            {
                                if (item.RoleId == _configuration.GetSection("Roles")["AplicationUser"])
                                {
                                    claims.Add(new Claim(ClaimTypes.Role, "AplicationUser"));
                                }
                                if (item.RoleId == _configuration.GetSection("Roles")["AplicationAdmin"])
                                {
                                    claims.Add(new Claim(ClaimTypes.Role, "AplicationAdmin"));
                                }
                                if (item.RoleId == _configuration.GetSection("Roles")["AplicationSeller"])
                                {
                                    claims.Add(new Claim(ClaimTypes.Role, "AplicationSeller"));
                                }

                                if (item.RoleId == _configuration.GetSection("Roles")["AplicationSupport"])
                                {
                                    claims.Add(new Claim(ClaimTypes.Role, "AplicationSupport"));
                                }
                            }

                            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);

                            var properties = new AuthenticationProperties()
                            {
                                IsPersistent = signInDTO.RememberMe
                            };

                            await HttpContext.SignInAsync(principal, properties);

                            TempData[SuccessMessage] = "ورود شما با موفقیت انجام شد";

                            return Redirect("/");

                        case Domain.DTOs.Auth.SignInResult.NotFound:
                            TempData[ErrorMessage] = "حساب کاربری پیدا نشد";
                            return View();
                        case Domain.DTOs.Auth.SignInResult.InActive:
                            TempData[ErrorMessage] = "حساب کاربری شما فعال نشده است";
                            return View();
                        default:
                            break;
                    }
                }
                TempData[ErrorMessage] = "اعتبار سنجی انجام نشد";
            }
            return View();
        }

        #endregion

        #region SignOut

        [Route("SignOut")]
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData[SuccessMessage] = "خروج با موفقیت انجام شد";
            return Redirect("/");
        }

        #endregion

        #region EmailConfirm

        public async Task<IActionResult> EmailConfirm(string id)
        {
            bool result = await _userservice.ConfirmEmail(id);

            if (result)
            {
                TempData[SuccessMessage] = "حساب کاربری شما با موفقیت فعال شد";
                return Redirect("/");
            }
            return NotFound();

        }

        #endregion

        #region ForgotPassword

        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            if (ModelState.IsValid)
            {
                if (await _captchaValidator.IsCaptchaPassedAsync(forgotPasswordDTO.Token))
                {
                    var result = await _userservice.ForgotPassword(forgotPasswordDTO);
                    switch (result)
                    {
                        case ForgotPasswordResult.Success:
                            TempData[InfoMessage] = "ایمیل فراموشی کلمه عبور برای شما ارسال شد";
                            return Redirect("/");

                        case ForgotPasswordResult.NotFound:
                            TempData[ErrorMessage] = "ایمیل الکترونیک وارد شده پیدا نشد";
                            return View();

                        case ForgotPasswordResult.InActive:
                            TempData[ErrorMessage] = "حساب کاربری شما فعال نشده است";
                            return View();

                        default:
                            break;
                    }
                }
            }
            return View();
        }

        #endregion

        #region ResetPassword


        public async Task<IActionResult> ResetPassword(string id)
        {
            var user = await _userservice.FindUserByActiveCode(id);

            if (user == null) return NotFound();

            var reset = new ResetPasswordDTO()
            {
                ActiveCode = id
            };


            return View(reset);

        }


        [ValidateAntiForgeryToken]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO dTO)
        {
            ModelState.Remove("ActiveCode");
            if (ModelState.IsValid)
            {
                if (await _captchaValidator.IsCaptchaPassedAsync(dTO.Token))
                {

                    bool result = await _userservice.ResetPassword(dTO);

                    if (!result) return NotFound();

                    TempData[SuccessMessage] = "رمز عبور شما با موفقیت تغییر کرد";

                    return RedirectToAction("SignIn");
                }
                TempData[ErrorMessage] = "اعتبار سنجی انجام نشد";
            }
            return NotFound();


        }
        #endregion

    }
}
