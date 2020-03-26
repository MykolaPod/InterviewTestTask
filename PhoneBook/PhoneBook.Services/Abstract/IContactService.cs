using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Dto.Response.Contact;

namespace PhoneBook.Services.Abstract
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDetailsDto>> GetContactDetails();
    }
}