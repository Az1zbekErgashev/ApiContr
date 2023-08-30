using WebApplication1.Enitiy;
namespace WebApplication1.Repository
{
    public interface IHomeWorkRepository
    {
        Task<List<HomeWork>> GetAllHomeWork();
        Task<HomeWork> GetHomeWorkById(int id);
        Task<HomeWork> CreateHome(HomeWork homeWork);
        System.Threading.Tasks.Task<HomeWork> UpdateHomeWork(HomeWork homeWork);
        System.Threading.Tasks.Task DeleteHomeWorkById(int id);
    }
}
