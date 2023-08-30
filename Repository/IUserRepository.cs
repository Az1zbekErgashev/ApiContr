using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(int id);
        Task<User> CreateUsers(User user);
        System.Threading.Tasks.Task<User> UpdateUsers(User user);
        System.Threading.Tasks.Task DeleteUsers(int id);
    }
}
