using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enitiy;
using WebApplication1.Repository;

namespace WebApplication1.Controllers

{
    [Route("api/[controller]")]

    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
       
        public ContactController(IContactRepository contactRepository) => _contactRepository = contactRepository;

        [HttpGet]
        public async Task<ActionResult<Contact>> GetContact() => Ok(await _contactRepository.GetAllContact());

        [HttpPost]
        public async Task<ActionResult> AddCourse(Contact contact) => Ok(await _contactRepository.CreateContactAsync(contact));
        [HttpDelete]
        public async Task<ActionResult> DeleteContact(int id)
        {
            await _contactRepository.DeleteContactAsync(id);
            return Ok("contact is delete");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(Contact contact) => Ok(await _contactRepository.UpdateContactAsync(contact));
    }
    
}
