using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Extentions;
using Shop.Application.Interfaces;
using Shop.Domain.DTOs.UserPanel;

namespace Shop.Web.Areas.User.Controllers
{
    public partial class HomeController : UserBaseController
    {
        private readonly IUserservice _userservice;
        private readonly ICaptchaValidator _captchaValidator;

        public HomeController(IUserservice userservice, ICaptchaValidator captchaValidator)
        {
            _userservice = userservice;
            _captchaValidator = captchaValidator;
        }
    }
    public partial class HomeController
    {
        public IActionResult Index()
        {
            return View();
        }


        #region UserDetails

        [HttpGet]
        [Route("User/UserDetails")]
        public async Task<IActionResult> UserDetails()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("User/UserDetails")]
        public async Task<IActionResult> UserDetails(UserDetailsDTO userDetailsDTO, IFormFile? avatar)
        {
            if (ModelState.IsValid)
            {
                if (await _captchaValidator.IsCaptchaPassedAsync(userDetailsDTO.Token))
                {
                    var result = await _userservice.EditUserDetails(userDetailsDTO, avatar, User.GetUserId());

                    if (result)
                    {
                        TempData[SuccessMessage] = "اطلاعات شما با موفقیت ثیت شد";
                        TempData[InfoMessage] = "لطفا دوباره وارد شوید";
                        return Redirect("/SignOut");
                    }
                    TempData[ErrorMessage] = "فرمت فایل انتخابی صحیح نیست";

                    return View();
                }
                TempData[ErrorMessage] = "اعتبار سنجی انجام نشد";
                return View(userDetailsDTO);
            }

            return View();
        }

        #endregion


        #region ResetPassword

        [HttpGet]
        [Route("User/ResetPassword")]
        public async Task<IActionResult> ResetPassword()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("User/ResetPassword")]
        public async Task<IActionResult> ResetPassword(UserResetPasswordDTO resetPasswordDTO)
        {

            if (ModelState.IsValid)
            {
                if (await _captchaValidator.IsCaptchaPassedAsync(resetPasswordDTO.Token))
                {
                    var result = await _userservice.ResetPassword(resetPasswordDTO, User.GetUserId());

                    switch (result)
                    {
                        case UserResetPasswordResult.WrongCurrentPassword:
                            TempData[ErrorMessage] = "رمز فعلی وارد شده صحیح نیست";
                            return View();

                        case UserResetPasswordResult.success:
                            TempData[SuccessMessage] = "رمز عبور با موفقیت تغییر پیدا کرد";
                            TempData[InfoMessage] = "لطفا دوباره وارد شوید";
                            return Redirect("/SignOut");

                        case UserResetPasswordResult.fail:
                            TempData[ErrorMessage] = "مشکلی پیش امد لطفا دوباره تلاش کنید";
                            return View();


                        case UserResetPasswordResult.NotFound:
                            TempData[ErrorMessage] = "مشکلی پیش امد لطفا دوباره تلاش کنید";
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


        #region StoreRequest

        [Route("StoreRequest")]
        [HttpGet]
        public IActionResult StoreRequest()
        {
            return View();
        }

        [Route("StoreRequest")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StoreRequest(UserStoreRequestDTO requestDTO, IFormFile storeImage)
        {
            if (ModelState.IsValid)
            {
                if (await _captchaValidator.IsCaptchaPassedAsync(requestDTO.Token))
                {
                    var result = await _userservice.AddStore(User.GetUserId(), requestDTO, storeImage);
                    switch (result)
                    {
                        case RequestStoreResult.Success:
                            TempData[SuccessMessage] = "درخواست شما با موفقیت ثبت شد";
                            TempData[InfoMessage] = "پاسخ شما به زودی ارسال خواهد شد";
                            return Redirect("User");

                        case RequestStoreResult.UserNotFound:
                            TempData[ErrorMessage] = "مشکلی پیش امد لطفا دوباره تلاش کنید";
                            return View(requestDTO);

                        case RequestStoreResult.HasUnderProgressRequest:
                            TempData[ErrorMessage] = "درخواست قیلی شما در حال پیگیری است";
                            TempData[InfoMessage] = "در حال حاضر نمی توانید درحواست جدید ثبت کنید";
                            return View(requestDTO);

                        case RequestStoreResult.NotImage:
                            TempData[ErrorMessage] = "فرمت فایل ارسالی صحیح نمی باشد";
                            return View(requestDTO);
                        default:
                            return View(requestDTO);
                    }
                }
            }

            return View();
        }

        #endregion


        #region StoreList

        [HttpGet]
        [Route("StoreList")]
        public async Task<IActionResult> StoreList(UserStoreFilterDTO storeFilterDTO)
        {
            storeFilterDTO.OrderBy = OrderBy.Order_DEC;
            storeFilterDTO.UserId = User.GetUserId();
          
            return View(await _userservice.FliterStore(storeFilterDTO, User.GetUserId()));
        }

        #endregion
    }
}
