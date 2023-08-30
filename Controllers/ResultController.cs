using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enitiy;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : Controller
    {
        private readonly IResultRepository _resultRepository;
        public ResultController(IResultRepository resultRepository) => _resultRepository = resultRepository;
        [HttpGet]
        public async Task<ActionResult<Enitiy.Result>> GetResults() => Ok(await _resultRepository.GetAllResults());

        [HttpPost]
        public async Task<ActionResult> AddResults(Enitiy.Result results) => Ok(await _resultRepository.CreateResult(results));
        [HttpDelete]
        public async Task<ActionResult> DeleteResluts(int id)
        {
            await _resultRepository.DeleteResultById(id);
            return Ok("Result is delete");
        }
        [HttpPut]
        public async Task<ActionResult<Result>> UpdateResult(Result result) => Ok(await _resultRepository.UpdateResult(result));
    }
}
