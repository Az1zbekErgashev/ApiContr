using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public interface IFeedbackRepository

    {
        Task<List<Feedback>> GetAllFeetback();
        Task<Feedback> GetFeedbackById(int id);
        Task<Feedback> CreateFeedback(Feedback feedback);
        System.Threading.Tasks.Task<Feedback> UpdateFeedback(Feedback feedback);
        System.Threading.Tasks.Task DeleteFeedback(int id);
    }
}
