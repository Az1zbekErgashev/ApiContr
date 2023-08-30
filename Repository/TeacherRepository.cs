using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;
        public TeacherRepository(AppDbContext context) => _context = context;

        public async Task<Teacher> CreateTecher(Teacher teacher)
        {
            var CurTechaer = new Teacher();
            CurTechaer.Id = teacher.Id;
            CurTechaer.Name = teacher.Name;
            CurTechaer.Url = teacher.Url;
            CurTechaer.Description = teacher.Description;

            _context.Teacher.Add(CurTechaer);
            await _context.SaveChangesAsync();
            return CurTechaer;
        }

        public async System.Threading.Tasks.Task DeleteTeacherById(int id)
        {
            var CurTeacher = await _context.Teacher.FindAsync(id);
            if( CurTeacher != null )
            {
                _context.Teacher.Remove(CurTeacher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Teacher>> GetAllTeachers() => await _context.Teacher.ToListAsync();

        public async Task<Teacher> GetTeacherById(int id)
        {
            return await _context.Teacher.FirstOrDefaultAsync(i => (Equals(i.Id, id)));
        }

        public async System.Threading.Tasks.Task<Teacher> UpdateTeacher(Teacher teacher)
        {
            var CurTeacher = await _context.Teacher.FindAsync(teacher.Id);
            if( CurTeacher != null )
            {
                CurTeacher.Name = teacher.Name;
                CurTeacher.Url = teacher.Url;
                CurTeacher.Description = teacher.Description;
                _context.Entry( CurTeacher ).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return CurTeacher;
        }
    }
}
