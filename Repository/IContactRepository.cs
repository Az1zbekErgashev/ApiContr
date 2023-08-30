using WebApplication1.Enitiy;
using Task = System.Threading.Tasks.Task;

namespace WebApplication1.Repository
{
    public interface IContactRepository
    {
        Task <List<Contact>> GetAllContact ();
        Task<Contact> GetContactByIdAsync (int id);
        Task<Contact> CreateContactAsync (Contact contact);
        Task<Contact> UpdateContactAsync (Contact contact);
        Task DeleteContactAsync (int id);
    }
}
