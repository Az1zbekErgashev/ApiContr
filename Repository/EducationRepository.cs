using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public class EducationRepository : IEducationRepository
    {
        private readonly AppDbContext _context;
        public EducationRepository(AppDbContext context) => _context = context;
        public async Task<List<Education>> GetAllEducation() => await _context.Education.ToListAsync();


        public async Task<Education> CreateEducation(Education education)
        {
            var CurEducation = new Education();


            CurEducation.Id = education.Id;
            CurEducation.course = await _context.Course.FirstOrDefaultAsync(i => i.Id == education.Id) ?? throw new BadHttpRequestException("User not found");
            CurEducation.Tranding = education.Tranding;
            CurEducation.courseСompletion = education.courseСompletion;
            CurEducation.Description = education.Description;

            _context.Education.Add(CurEducation);
            await _context.SaveChangesAsync();
            return CurEducation;

        }
        public async Task<Education> GetEducationById(int id)
        {
            return await _context.Education.FirstOrDefaultAsync(i =>(Equals(i.Id, id)));
        }
        public async System.Threading.Tasks.Task DeleteEducationById(int id)
        {
            var CurEducation = await _context.Education.FindAsync(id);
            if (CurEducation != null)
            {
                _context.Education.Remove(CurEducation);
                await _context.SaveChangesAsync();

            }
        }

 

        public async System.Threading.Tasks.Task<Education> UpdateEducation(Education education)
        {
            var CurEducation = await _context.Education.FindAsync(education.Id);
            if (CurEducation != null)
            {

                CurEducation.course = await _context.Course.FirstOrDefaultAsync(i => i.Id == education.Id) ?? throw new BadHttpRequestException("User not found");
                CurEducation.Tranding = education.Tranding;
                CurEducation.courseСompletion = education.courseСompletion;
                CurEducation.Description = education.Description;

                _context.Entry(CurEducation).State= EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return CurEducation;
        }
    }
}
