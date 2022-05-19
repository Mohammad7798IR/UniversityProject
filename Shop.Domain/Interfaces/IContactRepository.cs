using Shop.Domain.Entities.Contact;


namespace Shop.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<AppSetting> GetAppSetting();

        Task AddContactUs(ContactUs contactUs);

        Task SaveChanges();

        Task<List<QA>> GetQA();
    }
}
