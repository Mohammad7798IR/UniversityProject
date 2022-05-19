using MarketPlace.Application.Utils;
using Microsoft.AspNetCore.Http;
using Shop.Application.Extentions;
using Shop.Application.Interfaces;
using Shop.Domain.DTOs.Contact;
using Shop.Domain.Entities.Contact;
using Shop.Domain.Interfaces;
using System.Security.Claims;

namespace Shop.Application.Services
{
    public partial class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;


        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


    }
    public partial class ContactService
    {
        public async Task<AppSettingDTO> GetAppSettingInfo()
        {
            var appSettings = await _contactRepository.GetAppSetting();

            AppSettingDTO appSettingDTO = new AppSettingDTO()
            {
                Description = appSettings.Description,
                Email = appSettings.Email,
                PhoneNumber = appSettings.PhoneNumber,
            };

            return appSettingDTO;
        }

        public async Task<ContactUsDTO> GetAppSettingInfoForContactUs()
        {
            var settings = await _contactRepository.GetAppSetting();

            var contactDto = new ContactUsDTO()
            {
                SitePhoneNumber = settings.PhoneNumber,
                SiteEmail = settings.Email,

            };

            return contactDto;
        }

        public async Task<QaDTO> GetQAInfo()
        {
            var qa = await _contactRepository.GetQA();

            QaDTO qaDTO = new QaDTO()
            {
                QAs = qa
            };

            return qaDTO;
        }

        public async Task SubmitContactUs(ContactUsDTO contactUs, string userId, string userIp)
        {
            contactUs.Text = TextFixer.StripHTML(contactUs.Text);
            contactUs.Text = TextFixer.FixText(contactUs.Text);

            var contact = new ContactUs()
            {
                Id = Guid.NewGuid().ToString(),
                UserIp = userIp,
                Email = contactUs.Email,
                FullName = contactUs.FullName,
                Text = contactUs.Text,
                CreatedAt = UserExtention.GetPersianDateTime(DateTime.Now),
                Subject = contactUs.Subject,
                UserId = userId,

            };

            await _contactRepository.AddContactUs(contact);
            await _contactRepository.SaveChanges();
        }
    }
}
