using System;
using System.Threading.Tasks;
using Contracts.Dto.Request;
using Contracts.Dto.Request.Contact;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Services.Abstract;

namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetContacts([FromQuery] GetPagedItemsDto dto)
        {
            var result = await _contactService.GetContacts(dto);
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetContactsById([FromRoute] int id)
        {
            var result = await _contactService.GetContactById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateContact([FromBody] ContactCreateDto dto)
        {
            var result = await _contactService.CreateContact(dto);

            return CreatedAtAction(nameof(CreateContact), result);
        }
    }
}