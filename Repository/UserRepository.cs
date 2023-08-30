using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;
        public async Task<User> CreateUsers(User user)
        {
            var CurUsers = new User();
            CurUsers.Id = user.Id;
            CurUsers.FullName = user.FullName;
            CurUsers.Email = user.Email;
            CurUsers.Password = user.Password;

            _context.User.Add(CurUsers);
            await _context.SaveChangesAsync();
            return user;


        }

        public async System.Threading.Tasks.Task DeleteUsers(int id)
        {
            var CurUser = await _context.User.FindAsync(id);
            if (CurUser != null)
            {
                _context.User.Remove(CurUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsers() => await _context.User.ToListAsync();

        public async Task<User> GetById(int id) 
        {
            return await _context.User.FirstOrDefaultAsync(i => (Equals(i.Id, id)));
        }

        public async System.Threading.Tasks.Task<User> UpdateUsers(User user)
        {
            var CurUsers = await _context.User.FindAsync(user.Id);
            if(CurUsers != null)
            {
                CurUsers.FullName = user.FullName;
                CurUsers.Email = user.Email;
                CurUsers.Password = user.Password;

                _context.Entry(CurUsers).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            return CurUsers;

        }
    }
}
