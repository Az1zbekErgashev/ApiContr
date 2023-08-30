using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public interface IExcerptRepository
    {
        Task<List<excerpt>> GetAllExcerpt();
        Task <excerpt> GetExcerptById(int id);
        Task <excerpt> CreateExcerpt(excerpt excerpt);
        System.Threading.Tasks.Task<excerpt> UpdateExcerpt(excerpt excerpt);
        System.Threading.Tasks.Task DeleteExcerpt(int id);
    }
}
