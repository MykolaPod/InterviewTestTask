using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Dto.Response.Contact;
using PhoneBook.Services.Abstract;

namespace PhoneBook.Services
{
    public class ContactService : IContactService
    {
        public async Task<IEnumerable<ContactDetailsDto>> GetContactDetails()
        {
            throw new System.NotImplementedException();
        }
    }
}