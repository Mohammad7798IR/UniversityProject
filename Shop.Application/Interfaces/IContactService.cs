using Shop.Domain.DTOs.Contact;


namespace Shop.Application.Interfaces
{
    public interface IContactService
    {
        Task<AppSettingDTO> GetAppSettingInfo();

        Task<ContactUsDTO> GetAppSettingInfoForContactUs();

        Task SubmitContactUs(ContactUsDTO contactUs, string userId, string userIp);

        Task<QaDTO> GetQAInfo();
    }
}
