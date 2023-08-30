using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enitiy;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
      private readonly IEducationRepository _educationRepository;

        public EducationController(IEducationRepository educationRepository) => _educationRepository = educationRepository;
        [HttpGet]
        public async Task<ActionResult<Education>> GetEducation() => Ok(await _educationRepository.GetAllEducation());

        [HttpPost]
        public async Task<ActionResult> AddEducation(Education education) => Ok(await _educationRepository.CreateEducation(education));
        [HttpPut]
        public async Task<ActionResult> UpdateEducation(Education education) => Ok(await _educationRepository.UpdateEducation(education));
        [HttpDelete]
        public async Task<ActionResult> DeleteEducation(int id)
        {
            await _educationRepository.DeleteEducationById(id);
            return Ok("Education is delete");
        }
    }
}
