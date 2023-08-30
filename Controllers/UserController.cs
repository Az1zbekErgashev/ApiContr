using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enitiy;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) => _userRepository = userRepository;
        [HttpGet]
        public async Task <ActionResult<User>> GetUsers() => Ok(await _userRepository.GetAllUsers());
        [HttpPost]
        public async Task<ActionResult> AddUser(User user) => Ok(await _userRepository.CreateUsers(user));
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUsers(id);
            return Ok("User is delete");
        }
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user) => Ok(await _userRepository.UpdateUsers(user));

    }
}
