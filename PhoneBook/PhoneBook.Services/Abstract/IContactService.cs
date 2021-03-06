﻿using System.Threading.Tasks;
using Contracts.Dto.Request;
using Contracts.Dto.Request.Contact;
using Contracts.Dto.Response;
using Contracts.Dto.Response.Contact;

namespace PhoneBook.Services.Abstract
{
    public interface IContactService
    {
        Task<PagedDto<ContactDetailsDto>> GetContacts(GetPagedItemsDto dto);
        Task<ContactDetailsDto> GetContactById(int id);
        Task<ContactDetailsDto> CreateContact(ContactCreateDto dto);
        Task<ContactDetailsDto> UpdateContact(ContactUpdateDto dto);
        Task<ContactDetailsDto> DeleteContact(int id);
    }
}