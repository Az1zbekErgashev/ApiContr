using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using WebApplication1.Data;
using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public class HomeWorkRepository : IHomeWorkRepository
    {
        private readonly AppDbContext _context;
        public HomeWorkRepository(AppDbContext context) => _context = context;

        public async Task<HomeWork> CreateHome(HomeWork homeWork)
        {
            var cur = new HomeWork();
            cur.Id = homeWork.Id;
            cur.Img = homeWork.Img;
            cur.Title = homeWork.Title;
            cur.Name = homeWork.Name;
            cur.Lessons = await _context.Lessons.FirstOrDefaultAsync(i => i.Id == homeWork.Id) ?? throw new BadHttpRequestException("User not found");
            cur.Task = await _context.Task.FirstOrDefaultAsync(i => i.Id == homeWork.Id) ?? throw new BadHttpRequestException("User not found"); 

            _context.HomeWork.Add(cur);
            await _context.SaveChangesAsync();
            return cur;
        }

        public async System.Threading.Tasks.Task DeleteHomeWorkById(int id)
        {
            var CurEducation = await _context.HomeWork.FindAsync(id);
            if (CurEducation != null)
            {
                _context.HomeWork.Remove(CurEducation);
                await _context.SaveChangesAsync();

            }
        }

        public Task<List<HomeWork>> GetAllHomeWork()
        {
            throw new NotImplementedException();
        }

        public async Task<HomeWork> GetHomeWorkById(int id)
        {
            return await _context.HomeWork.FirstOrDefaultAsync(i => Equals(i.Id, id));
        }

        public async System.Threading.Tasks.Task<HomeWork> UpdateHomeWork(HomeWork homeWork)
        {
            var CurExcerpt = await _context.HomeWork.FindAsync(homeWork.Id);

            if (CurExcerpt != null)
            {
                CurExcerpt.Img = homeWork.Img;
                CurExcerpt.Title = homeWork.Title;
                CurExcerpt.Name = homeWork.Name;
                CurExcerpt.Lessons = await _context.Lessons.FirstOrDefaultAsync(i => i.Id == homeWork.Id) ?? throw new BadHttpRequestException("User not found");
                CurExcerpt.Task = await _context.Task.FirstOrDefaultAsync(i => i.Id == homeWork.Id) ?? throw new BadHttpRequestException("User not found");

                _context.Entry(CurExcerpt).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return CurExcerpt;
        }
    }
}
