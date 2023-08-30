using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public interface IEducationRepository
    {

        Task<List<Education>> GetAllEducation();
        Task <Education> GetEducationById(int id);
        Task<Education> CreateEducation(Education education);
        System.Threading.Tasks.Task<Education> UpdateEducation(Education education);
        System.Threading.Tasks.Task DeleteEducationById(int id);
 
    }
}
