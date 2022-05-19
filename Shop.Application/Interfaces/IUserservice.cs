using Microsoft.AspNetCore.Http;
using Shop.Domain.DTOs.Auth;
using Shop.Domain.DTOs.UserPanel;
using Shop.Domain.Entities.Identity;
using Shop.Domain.Entities.MarketPlaceStore;

namespace Shop.Application.Interfaces
{
    public partial interface IUserservice
    {
        Task<SginUpResult> SginUp(SignUpDTO signUpDTO);

        Task<SignInResult> SginIn(SignInDTO signInDTO);

        Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);

        Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO);

        Task<ApplicationUser> FindUserAndRolesByEmail(string email);

        Task<ApplicationUser> FindUserAndRolesById(string userId);



        Task<ApplicationUser> FindUserById(string id);

        Task<ApplicationUser> FindUserByActiveCode(string activeCode);

        Task<bool> ConfirmEmail(string activeCode);
    }

    #region UserPanel

    public partial interface IUserservice
    {
        Task<bool> EditUserDetails(UserDetailsDTO detailsDTO, IFormFile? avatar, string userId);

        Task<UserResetPasswordResult> ResetPassword(UserResetPasswordDTO resetPasswordDTO, string userId);

        Task<RequestStoreResult> AddStore(string userId, UserStoreRequestDTO userStoreRequestDTO, IFormFile storeImage);

        Task<UserStoreFilterDTO> FliterStore(UserStoreFilterDTO storeDto, string userId);

        Task<ApplicationUser> GetUserAsync(string userId);

        Task<Store> GetStore(string userId);

        Task<bool> HasUserGotAcceptedStoreByUserId(string userId);

    }

    #endregion
}
