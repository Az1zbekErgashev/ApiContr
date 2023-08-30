using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        public ContactRepository(AppDbContext context) => _context = context;

  
        public async Task<List<Contact>> GetAllContact() => await _context.Contact.ToListAsync();

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _context.Contact.FirstOrDefaultAsync(i => (Equals(i.Id, id)));
        }
        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            var CurContact = new Contact();

            CurContact.Id = contact.Id;
            CurContact.PhoneNumber = contact.PhoneNumber;
            CurContact.Email = contact.Email;
            CurContact.Location = contact.Location;
            CurContact.User = await _context.User.FirstOrDefaultAsync(i => i.Id == contact.Id) ?? throw new BadHttpRequestException("User not found");

            _context.Contact.Add(CurContact);
            await _context.SaveChangesAsync();
            return CurContact;
        }

        public async System.Threading.Tasks.Task<Contact> UpdateContactAsync(Contact contact)
        {
            var CurContact = await _context.Contact.FirstOrDefaultAsync();
            if(CurContact == null)
            {
                CurContact.PhoneNumber = contact.PhoneNumber;
                CurContact.Email = contact.Email;
                CurContact.Location = contact.Location;
                CurContact.User = await _context.User.FirstOrDefaultAsync(i => i.Id == contact.Id) ?? throw new BadHttpRequestException("User not found");
                _context.Entry(CurContact).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return CurContact;
        }
        public async System.Threading.Tasks.Task DeleteContactAsync(int id)
        {
            var CurContact = await _context.Contact.FindAsync(id);
            if (CurContact != null)
            {
                _context.Contact.Remove(CurContact);
                await _context.SaveChangesAsync();
            }
        }

    }
     
}