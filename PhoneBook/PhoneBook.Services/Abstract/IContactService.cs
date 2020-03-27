using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Dto.Request;
using Contracts.Dto.Request.Contact;
using Contracts.Dto.Response;
using Contracts.Dto.Response.Contact;

namespace PhoneBook.Services.Abstract
{
    public interface IContactService
    {
        Task<PagedDto<ContactDetailsDto>> GetContacts(GetPagedItemsDto dto);
    }
}