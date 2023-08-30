using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public class FeedBackRepository : IFeedbackRepository
    {
        private AppDbContext _context;
        public FeedBackRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Feedback> CreateFeedback(Feedback feedback)
        {
            var cur = new Feedback();

            cur.Id = feedback.Id;
            cur.Name = feedback.Name;   
            cur.Phone_Number = feedback.Phone_Number;
            cur.Date = feedback.Date;
            cur.User = await _context.User.FirstOrDefaultAsync(i => i.Id == feedback.Id) ?? throw new BadHttpRequestException("User not found"); 
            cur.Education = await _context.Education.FirstOrDefaultAsync(i => i.Id == feedback.Id) ?? throw new BadHttpRequestException("User not found");

            _context.Feedback.Add(cur);
            await _context.SaveChangesAsync();
            return cur;
        }

        public async System.Threading.Tasks.Task DeleteFeedback(int id)
        {
            var cur = await _context.Feedback.FindAsync(id);
            if (cur != null)
            {
                _context.Feedback.Remove(cur);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Feedback>> GetAllFeetback() => await _context.Feedback.ToListAsync();

        public async Task<Feedback> GetFeedbackById(int id)
        {
            return await _context.Feedback.FirstOrDefaultAsync(i => (Equals(i.Id, id)));
        }

        public async System.Threading.Tasks.Task<Feedback> UpdateFeedback(Feedback feedback)
        {
            var cur = await _context.Feedback.FindAsync(feedback.Id);
            if(cur != null)
            {
                cur.Name = feedback.Name;
                cur.Phone_Number = feedback.Phone_Number;
                cur.Date = feedback.Date;
                cur.User = await _context.User.FirstOrDefaultAsync(i => i.Id == feedback.Id) ?? throw new BadHttpRequestException("User not found");
                cur.Education = await _context.Education.FirstOrDefaultAsync(i => i.Id == feedback.Id) ?? throw new BadHttpRequestException("User not found");

                _context.Entry(cur).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return cur;
        }
    }
}
