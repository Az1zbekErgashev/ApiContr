using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enitiy;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewController(IReviewRepository reviewRepository) => _reviewRepository = reviewRepository;

        [HttpGet]
        public async Task<ActionResult<Review>> GetReview() => Ok(await _reviewRepository.GetAllReviews());
        [HttpPost]
        public async Task<ActionResult> AddReview(Review review) => Ok(await _reviewRepository.CreateReview(review));
        [HttpDelete]
        public async Task<ActionResult> DeleteReview(int id)
        {
            await _reviewRepository.DeleteReview(id);
            return Ok("Review is delete");
        }
        [HttpPut]
        public async Task<ActionResult<Review>> UpdateReview(Review review) => Ok(await _reviewRepository.UpdateReview(review));
    }
}
