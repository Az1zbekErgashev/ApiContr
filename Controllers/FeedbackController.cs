using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enitiy;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository) => _feedbackRepository = feedbackRepository;
        [HttpGet]
        public async Task<ActionResult<Feedback>> GetFeedBack() => Ok(await _feedbackRepository.GetAllFeetback());
        [HttpPost]
        public async Task<ActionResult> AddFeedback(Feedback feedback) => Ok(await _feedbackRepository.CreateFeedback(feedback));
        [HttpDelete]
        public async Task<ActionResult> DeleteFeedback(int id)
        {
            await _feedbackRepository.DeleteFeedback(id);
            return Ok("Feedback is delete");
        }
        [HttpPut]
        public async Task<ActionResult<Feedback>> UpdateExcerpt(Feedback feedback) => Ok(await _feedbackRepository.UpdateFeedback(feedback));
    }
}
