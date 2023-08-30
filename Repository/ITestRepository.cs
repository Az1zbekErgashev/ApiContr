using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public interface ITestRepository
    {
        Task<List<Tests>> GetAllTest();
        Task <Tests> GetTestById(int id);
        Task <Tests> CreateTest(Tests test);
        System.Threading.Tasks.Task<Tests> UpdateTest(Tests test);
        System.Threading.Tasks.Task DeleteTest(int id);
    }
}
