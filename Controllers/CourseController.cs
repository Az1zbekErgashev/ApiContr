using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enitiy;
using WebApplication1.Repository;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]

[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;

    public CourseController(ICourseRepository courseRepository) => _courseRepository = courseRepository;

    [HttpGet]
    public async Task<ActionResult<Course>> GetCourses() => Ok(await _courseRepository.GetCourseAllAsync());

    [HttpPost]
    public async Task<ActionResult> AddCourse(Course course) => Ok(await _courseRepository.CreateCourseAsync(course));
    [HttpDelete]
    public async Task<ActionResult> DeleteCourse(int id)
    {
        await _courseRepository.DeleteCourseAsync(id);
        return Ok("course is delete");
    }
    [HttpPut]
    public async Task<ActionResult> UpdateResult(Course course) => Ok(await _courseRepository.UpdateCourseAsync(course));
    
}