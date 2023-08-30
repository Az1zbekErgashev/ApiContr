using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeachers();
        Task <Teacher> GetTeacherById(int id);
        Task <Teacher> CreateTecher(Teacher teacher);
        System.Threading.Tasks.Task<Teacher> UpdateTeacher(Teacher teacher);
        System.Threading.Tasks.Task DeleteTeacherById(int id);
    }
}
