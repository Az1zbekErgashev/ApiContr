using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public interface ILessonsRepository
    {
        Task<List<Lessons>> GetAllLessons();
        Task<Lessons> GetLessonsById(int id);
        Task<Lessons> CreateLesson(Lessons lessons);
        System.Threading.Tasks.Task<Lessons> UpdateLessons(Lessons lessons);
        System.Threading.Tasks.Task DeleteLessonsById(int id);

    }
}
