using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplication1.Enitiy;
using WebApplication1.Repository;
namespace WebApplication1.Controllers
{
        [Route("api/[controller]")]

        [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository) => _teacherRepository = teacherRepository;
        [HttpGet]
        public async Task<ActionResult<Teacher>> GetTeacher() => Ok(await _teacherRepository.GetAllTeachers());
        [HttpPost]
        public async Task<ActionResult> AddTechaer(Teacher teacher) => Ok(await _teacherRepository.CreateTecher(teacher));
        [HttpDelete]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            await _teacherRepository.DeleteTeacherById(id);
            return Ok("Teacher is delete");
        }
        [HttpPut]
        public async Task<ActionResult<Teacher>> UpdateReview(Teacher teacher) => Ok(await _teacherRepository.UpdateTeacher(teacher));
    }
}
