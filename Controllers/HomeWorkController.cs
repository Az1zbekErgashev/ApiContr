using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enitiy;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class HomeWorkController : ControllerBase
    {
        private readonly IHomeWorkRepository _homeWorkRepository;
        public HomeWorkController( IHomeWorkRepository excerptRepository) => _homeWorkRepository = excerptRepository;
        [HttpGet]
        public async Task<ActionResult<HomeWork>> GetExcerpt() => Ok(await _homeWorkRepository.GetAllHomeWork());
        [HttpPost]
        public async Task<ActionResult> AddExcerpt(HomeWork homeWork) => Ok(await _homeWorkRepository.CreateHome(homeWork));
        [HttpDelete]
        public async Task<ActionResult> DeleteHomeWork(int id)
        {
            await _homeWorkRepository.DeleteHomeWorkById(id);
            return Ok("HomeWork is delete");
        }
        [HttpPut]
        public async Task<ActionResult<HomeWork>> UpdateHomeWork(HomeWork homeWork) => Ok(await _homeWorkRepository.UpdateHomeWork(homeWork));

    }
}
