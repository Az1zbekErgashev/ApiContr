using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public interface IResultRepository
    {
        Task<List<Result>> GetAllResults();  
        Task<Result> GetResultById(int id);
        Task<Result> CreateResult(Result result);
        System.Threading.Tasks.Task<Result> UpdateResult(Result result);
        System.Threading.Tasks.Task DeleteResultById(int id);
    }
}
