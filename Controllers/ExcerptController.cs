using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enitiy;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class ExcerptController : ControllerBase
    {
       private readonly IExcerptRepository _excerptRepository;
        public ExcerptController(IExcerptRepository excerptRepository) => _excerptRepository = excerptRepository;
        [HttpGet]
        public async Task<ActionResult<excerpt>> GetExcerpt() => Ok(await _excerptRepository.GetAllExcerpt());
        [HttpPost]
        public async Task<ActionResult> AddExcerpt(excerpt excerpt) => Ok(await _excerptRepository.CreateExcerpt(excerpt));
        [HttpDelete]
        public async Task<ActionResult> DeleteExcerpt(int id)
        {
            await _excerptRepository.DeleteExcerpt(id);
            return Ok("Excerpt is delete");
        }
        [HttpPut]
        public async Task<ActionResult<excerpt>> UpdateExcerpt(excerpt excerpt) => Ok(await _excerptRepository.UpdateExcerpt(excerpt));

    }
}
