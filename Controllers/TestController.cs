using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Enitiy;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        public TestController(ITestRepository testRepository) => _testRepository = testRepository;
        [HttpGet]
        public async Task<ActionResult<Tests>> GetTests() => Ok(await _testRepository.GetAllTest());
        [HttpPost]
        public async Task<ActionResult> AddTest(Tests tests) => Ok(await _testRepository.CreateTest(tests));
        [HttpDelete]
        public async Task<ActionResult> DeleteTest(int id)
        {
            await _testRepository.DeleteTest(id);
            return Ok("Test is delete");
        }
        [HttpPut]
        public async Task<ActionResult<Teacher>> UpdateTest(Tests tests) => Ok(await _testRepository.UpdateTest(tests));

    }
}
