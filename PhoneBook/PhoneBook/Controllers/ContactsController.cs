using System;
using System.Threading.Tasks;
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


        [HttpGet]
        public async Task<IActionResult> Contacts()
        {
            return Ok();
        }
    }
}