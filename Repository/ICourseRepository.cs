using WebApplication1.Enitiy;
using Task = System.Threading.Tasks.Task;

namespace WebApplication1.Repository;

public interface ICourseRepository
{
    Task<List<Course>> GetCourseAllAsync();
    Task<Course> GetCourseByIdAsync(int id);
    Task<Course> CreateCourseAsync(Course course);
    Task<Course> UpdateCourseAsync(Course course);
    Task DeleteCourseAsync(int id);

}