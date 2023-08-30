using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using WebApplication1.Data;
using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public class LessonRepository : ILessonsRepository
    {
        private readonly AppDbContext _context;
        public LessonRepository(AppDbContext context) => _context = context;
        public async Task<Lessons> CreateLesson(Lessons lessons)
        {
            var cur = new Lessons();
            cur.Id = lessons.Id;
            cur.Title = lessons.Title;
            cur.Video_url = lessons.Video_url;
            cur.Description = lessons.Description;
            cur.Vedeo_url2 = lessons.Vedeo_url2;

            _context.Lessons.Add(cur);
            await _context.SaveChangesAsync();
            return cur;

        }

        public async System.Threading.Tasks.Task DeleteLessonsById(int id)
        {
            var cur = await _context.Lessons.FindAsync(id);
            if (cur != null)
            {
                _context.Lessons.Remove (cur);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Lessons>> GetAllLessons() => await _context.Lessons.ToListAsync();

        public async Task<Lessons> GetLessonsById(int id) => await _context.Lessons.FirstOrDefaultAsync(i => (Equals(i.Id, id)));

        public async System.Threading.Tasks.Task<Lessons> UpdateLessons(Lessons lessons)
        {
            var cur = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == lessons.Id);
            if (cur != null)
            {
                cur.Id = lessons.Id;
                cur.Title = lessons.Title;
                cur.Video_url = lessons.Video_url;
                cur.Description = lessons.Description;
                cur.Vedeo_url2 = lessons.Vedeo_url2;


                _context.Entry(cur).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return cur;
        }
    }
}
