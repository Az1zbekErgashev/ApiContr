using WebApplication1.Enitiy;
using Task = System.Threading.Tasks.Task;

namespace WebApplication1.Repository;

public interface IReviewRepository
{
    Task<List<Review>> GetAllReviews();
    Task<Review> GetReviewById(int id);
    Task<Review> CreateReview(Review review);
    Task<Review> UpdateReview(Review review);
    Task DeleteReview(int id);

}
