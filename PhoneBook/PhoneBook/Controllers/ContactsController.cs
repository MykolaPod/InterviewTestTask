using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class ContactsController : ControllerBase
    {

        public ContactsController()
        {
            
        }


        [HttpGet]
        public async Task<IActionResult> Contacts()
        {
            return Ok();
        }
    }
}