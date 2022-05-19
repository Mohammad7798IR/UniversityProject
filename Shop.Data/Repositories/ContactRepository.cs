using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Domain.Entities.Contact;
using Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        private readonly MollaShopDBContext _context;

        public ContactRepository(MollaShopDBContext context)
        {
            _context = context;
        }

     
    }
    public partial class ContactRepository
    {
        public async Task<AppSetting> GetAppSetting()
        {
            return await _context.AppSetting
                .SingleOrDefaultAsync();
        }

        public async Task<List<QA>> GetQA()
        {
            return await _context.QA.Where(x => x.Id != null).ToListAsync();
        }

        public async Task AddContactUs(ContactUs contactUs)
        {
            await _context.ContactUs.AddAsync(contactUs);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
