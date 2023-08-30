using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly AppDbContext _context;
        public TestRepository(AppDbContext context) => _context = context;
        public async Task<Tests> CreateTest(Tests test)
        {
            var CurTest = new Tests();
            CurTest.Id = test.Id;
            CurTest.Answers = test.Answers;
            CurTest.Queshioquestion = test.Queshioquestion;

            _context.Tests.Add(CurTest);
            await _context.SaveChangesAsync();
            return CurTest;
            
        }

        public async System.Threading.Tasks.Task DeleteTest(int id)
        {
            var CurTest = await _context.Tests.FindAsync(id);
                if(CurTest != null)
            {
                _context.Tests.Remove(CurTest);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<Tests>> GetAllTest() => await _context.Tests.ToListAsync();

        public async Task<Tests> GetTestById(int id)
        {
            return await _context.Tests.FirstOrDefaultAsync(i => (Equals(i.Id, id)));
        }

        public async System.Threading.Tasks.Task<Tests> UpdateTest(Tests test)
        {
            var CurTest = await _context.Tests.FindAsync(test.Id);

          if( CurTest != null)
            {
                CurTest.Answers = test.Answers;
                CurTest.Queshioquestion = test.Queshioquestion;

                _context.Entry(CurTest).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return CurTest;
        }
    }
}
