using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enitiy;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : Controller
    {
        private readonly ILessonsRepository _lessonsRepository;
        public LessonsController(ILessonsRepository lessonsRepository) => _lessonsRepository = lessonsRepository;
        [HttpGet]
        public async Task<ActionResult<Lessons>> GetLessons() => Ok(await _lessonsRepository.GetAllLessons());
        [HttpPost]
        public async Task<ActionResult> AddLesson(Lessons lessons) => Ok(await _lessonsRepository.CreateLesson(lessons));
        [HttpDelete]
        public async Task<ActionResult> DeleteLessons(int id)
        {
            await _lessonsRepository.DeleteLessonsById(id);
            return Ok("Lesson is delete");
        }
        [HttpPut]
        public async Task<ActionResult<Lessons>> UpdateLessons(Lessons lessons) => Ok(await _lessonsRepository.UpdateLessons(lessons));
    }
}
