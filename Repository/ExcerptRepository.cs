using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public class ExcerptRepository : IExcerptRepository
    {
        private readonly AppDbContext _context;
        public ExcerptRepository(AppDbContext context)=> _context = context;

    
        public async Task<excerpt> CreateExcerpt(excerpt excerpt)
        {
            var CurExcerpt = new excerpt();

            CurExcerpt.Id = excerpt.Id;
            CurExcerpt.Url = excerpt.Url;
            CurExcerpt.result = await _context.Result.FirstOrDefaultAsync(i => i.ID == excerpt.Id) ?? throw new BadHttpRequestException("User not found");

            _context.excerpt.Add(CurExcerpt);
            await _context.SaveChangesAsync();
            return excerpt;

        }

        public async System.Threading.Tasks.Task DeleteExcerpt(int id)
        {
            var CurExcerpt = await _context.excerpt.FindAsync(id);
            if( CurExcerpt == null)
            {
                _context.excerpt.Remove(CurExcerpt);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<excerpt>> GetAllExcerpt() => await _context.excerpt.ToListAsync();


        public async Task<excerpt> GetExcerptById(int id)
        {
            return await _context.excerpt.FirstOrDefaultAsync(i => Equals(i.Id, id));

        }


        public async System.Threading.Tasks.Task<excerpt> UpdateExcerpt(excerpt excerpt)
        {
            var CurExcerpt = await _context.excerpt.FindAsync(excerpt.Id);
            if (CurExcerpt == null)
            {
                CurExcerpt.Url = excerpt.Url;
                CurExcerpt.result = await _context.Result.FirstOrDefaultAsync(i => i.ID == excerpt.Id) ?? throw new BadHttpRequestException("User not found");


                _context.Entry(CurExcerpt).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return CurExcerpt;
        }

    }
}
