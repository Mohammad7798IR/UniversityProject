using MarketPlace.Application.Extensions;
using MarketPlace.Application.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SendEmail;
using Shop.Application.Extentions;
using Shop.Application.Interfaces;
using Shop.Application.Utils;
using Shop.Domain.DTOs.Auth;
using Shop.Domain.DTOs.UserPanel;
using Shop.Domain.Entities.Identity;
using Shop.Domain.Entities.MarketPlaceStore;
using Shop.Domain.Interfaces;
using Shop.Domain.DTOs.Paging;
using MarketPlace.DataLayer.Repository;

namespace Shop.Application.Services
{
    public partial class UserService : IUserservice
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IViewRenderService _viewRenderService;
        private readonly IStoreRepository _storeRepository;
        private readonly IGenericRepository<Store> _genericRepository;

        public UserService(IUserRepository userRepository, 
            IConfiguration configuration, IViewRenderService viewRenderService, 
            IStoreRepository storeRepository,
            IGenericRepository<Store> genericRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _viewRenderService = viewRenderService;
            _storeRepository = storeRepository;
            _genericRepository = genericRepository;
        }

       
    }

    #region Auth
    public partial class UserService
    {
        public async Task<SginUpResult> SginUp(SignUpDTO signUpDTO)
        {


            if (await _userRepository.UserNameExists(signUpDTO.Username))
            {
                return SginUpResult.UserNameExits;
            }

            if (await _userRepository.EmailExists(signUpDTO.Email))
            {
                return SginUpResult.EmailExits;
            }


            EmailSender sender = new EmailSender(_configuration);

            ApplicationUser newUser = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                Gender = Gender.Unknown,
                Email = signUpDTO.Email,
                PasswordHash = HashGenerator.GeneratePassword(signUpDTO.Password),
                ActiveCode = Guid.NewGuid().ToString(),
                EmailConfirmed = false,
                UserName = signUpDTO.Username,
                CreatedAt = UserExtention.GetPersianDateTime(DateTime.Now).ToString(),
            };

            var userRole = new ApplicationUserRole();


            userRole.Id = Guid.NewGuid().ToString();
            userRole.UserId = newUser.Id;
            userRole.RoleId = _configuration.GetSection("Roles")["AplicationUser"];

            List<ApplicationUserRole> lst = new List<ApplicationUserRole>();

            lst.Add(userRole);

            newUser.userRoles = lst;

            await _userRepository.AddUser(newUser);

            string template = _viewRenderService.RenderToStringAsync("_ActiveEmailTemplate", newUser);
            await sender.SendEmail(signUpDTO.Email, "فعال سازی", template);

            return SginUpResult.Success;

        }

        public async Task<SignInResult> SginIn(SignInDTO signInDTO)
        {
            var user = await _userRepository.FindUserByEmail(signInDTO.Email);

            if (user == null) return SignInResult.NotFound;

            if (!user.EmailConfirmed) return SignInResult.InActive;

            if (!HashGenerator.CheckPassword(user.PasswordHash, signInDTO.Password)) return SignInResult.NotFound;

            return SignInResult.Success;
        }

        public async Task<ApplicationUser> FindUserAndRolesByEmail(string email)
        {
            return await _userRepository.FindUserAndRolesByEmail(email);
        }

        public async Task<ApplicationUser> FindUserByActiveCode(string activeCode)
        {
            return await _userRepository.FindUserByActiveCode(activeCode);
        }

        public async Task<ApplicationUser> FindUserById(string id)
        {
            return await _userRepository.FindUserById(id);
        }

        public async Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            var user = await _userRepository.FindUserByEmail(forgotPasswordDTO.Email);

            if (user == null) return ForgotPasswordResult.NotFound;

            if (!user.EmailConfirmed) return ForgotPasswordResult.InActive;

            EmailSender sender = new EmailSender(_configuration);

            await sender.SendEmail(forgotPasswordDTO.Email, "فراموشی کلمه عبور", _viewRenderService.RenderToStringAsync("_ForgotPasswordTemplate", user));

            return ForgotPasswordResult.Success;


        }

        public async Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var user = await _userRepository.FindUserByActiveCode(resetPasswordDTO.ActiveCode);

            if (user == null) return false;

            user.ActiveCode = Guid.NewGuid().ToString();
            user.UpdatedAt = UserExtention.GetPersianDateTime(DateTime.Now).ToString();
            user.PasswordHash = HashGenerator.GeneratePassword(resetPasswordDTO.Password);

            _userRepository.UpdateUser(user);
            await _userRepository.SaveChanges();

            return true;
        }

        public async Task<bool> ConfirmEmail(string activeCode)
        {
            var user = await _userRepository.FindUserByActiveCode(activeCode);

            if (user == null) return false;

            user.EmailConfirmed = true;
            user.ActiveCode = Guid.NewGuid().ToString();

            _userRepository.UpdateUser(user);
            await _userRepository.SaveChanges();

            return true;
        }
    }
    #endregion


    #region UserPanel

    public partial class UserService
    {
        public async Task<bool> EditUserDetails(UserDetailsDTO detailsDTO, IFormFile? avatar, string userId)
        {
            if (avatar == null)
            {
                var user = await _userRepository.FindUserById(userId);


                user.UpdatedAt = UserExtention.GetPersianDateTime(DateTime.Now);
                user.BirthDate = detailsDTO.BirthDate;
                user.LastName = detailsDTO.LastName;
                user.FirstName = detailsDTO.FirstName;
                user.PhoneNumber = detailsDTO.PhoneNumber;
                user.Gender = detailsDTO.Gender;

                _userRepository.UpdateUser(user);

                await _userRepository.SaveChanges();

                return true;
            }

            else
            {
                if (!avatar.IsImage())
                {
                    return false;
                }

                var user = await _userRepository.FindUserById(userId);

                var avatarName = Guid.NewGuid().ToString() + Path.GetExtension(avatar.FileName);

                user.UpdatedAt = UserExtention.GetPersianDateTime(DateTime.Now);
                user.Avatar = avatarName;
                user.BirthDate = detailsDTO.BirthDate;
                user.LastName = detailsDTO.LastName;
                user.FirstName = detailsDTO.FirstName;
                user.PhoneNumber = detailsDTO.PhoneNumber;
                user.Gender = detailsDTO.Gender;


                avatar.AddImageToServer(avatarName, FilePath.AvatarServerOrigin, 100, 100, FilePath.AvatarServerThumb, user.Avatar);


                _userRepository.UpdateUser(user);

                await _userRepository.SaveChanges();

                return true;
            }

        }

        public async Task<UserResetPasswordResult> ResetPassword(UserResetPasswordDTO resetPasswordDTO, string userId)
        {
            var user = await _userRepository.FindUserById(userId);

            if (user == null)
                return UserResetPasswordResult.NotFound;

            if (!HashGenerator.CheckPassword(user.PasswordHash, resetPasswordDTO.CurrentPassword))
                return UserResetPasswordResult.WrongCurrentPassword;


            user.PasswordHash = HashGenerator.GeneratePassword(resetPasswordDTO.Password);
            user.UpdatedAt = UserExtention.GetPersianDateTime(DateTime.Now);


            _userRepository.UpdateUser(user);
            await _userRepository.SaveChanges();

            return UserResetPasswordResult.success;


        }

        public async Task<ApplicationUser> FindUserAndRolesById(string userId)
        {
            return await _userRepository.FindUserAndRolesById(userId);
        }

        public async Task<RequestStoreResult> AddStore(string userId, UserStoreRequestDTO userStoreRequestDTO, IFormFile storeImage)
        {

            if (storeImage == null) return RequestStoreResult.NotImage;

            if (!storeImage.IsImage()) return RequestStoreResult.NotImage;

            var user = await _userRepository.FindUserById(userId);

            if (user == null) return RequestStoreResult.UserNotFound;


            foreach (var item in await _userRepository.FindStoresByUserId(userId))
            {
                if (item.StoreAcceptanceState == StoreAcceptanceState.UnderProgress)
                {
                    return RequestStoreResult.HasUnderProgressRequest;
                }
            }

            var imageName = Guid.NewGuid().ToString() + Path.GetExtension(storeImage.FileName);

            var newStore = new Store()
            {
                Id = Guid.NewGuid().ToString(),
                Address = userStoreRequestDTO.Address,
                CreatedAt = UserExtention.GetPersianDateTime(DateTime.Now),
                Phone = userStoreRequestDTO.Phone,
                StoreAcceptanceState = StoreAcceptanceState.UnderProgress,
                StoreName = userStoreRequestDTO.StoreName,
                UserId = user.Id,
                IsDeleted = false,
                StoreImage = imageName,
                AdminDescription = "بررسی نشده",
                Description = "بررسی نشده",
                StoreAcceptanceDescription = "بررسی نشده",
                Mobile = " ",


            };

            storeImage.AddImageToServer(imageName, FilePath.StoreServerOrigin, 100, 100, FilePath.StoreServerThumb);


            await _userRepository.AddStore(newStore);
            await _userRepository.SaveChanges();

            return RequestStoreResult.Success;

        }

        public async Task<UserStoreFilterDTO> FliterStore(UserStoreFilterDTO storeDto, string userId)
        {
            var query = _genericRepository.GetQuery().AsQueryable();

            query = query.Where(x=>x.UserId==storeDto.UserId);

            #region state

            switch (storeDto.StoreAcceptanceState)
            {
                case StoreAcceptanceState.UnderProgress:
                    break;
                case StoreAcceptanceState.Accepted:
                    query = query.Where(s => s.StoreAcceptanceState==StoreAcceptanceState.Accepted);
                    break;
                case StoreAcceptanceState.Rejected:
                    query = query.Where(s => s.StoreAcceptanceState == StoreAcceptanceState.Rejected);
                    break;
            }

            switch (storeDto.OrderBy)
            {
                case OrderBy.Order_ACE:
                    query = query.OrderBy(s => s.CreatedAt);
                    break;
                case OrderBy.Order_DEC:
                    query = query.OrderByDescending(s => s.CreatedAt);
                    break;
            }

            #endregion

            #region paging

            var pager = Pager.Build(storeDto.PageId,  query.Count(), storeDto.TakeEntity, storeDto.HowManyShowPageAfterAndBefore);

            var allEntities = query.Paging(pager).ToList();

            #endregion

            return storeDto.SetPaging(pager).SetStores(allEntities);

        }

        public async Task<ApplicationUser> GetUserAsync(string userId)
        {
            return await _userRepository.FindUserById(userId);
        }

        public async Task<Store> GetStore(string userId)
        {
            return await _userRepository.GetStoreByUserId(userId);
        }


        public async Task<bool> HasUserGotAcceptedStoreByUserId(string userId)
        {
            return await _userRepository.HasUserGotAcceptedStoreByUserId(userId);
        }
    }

    #endregion
}
