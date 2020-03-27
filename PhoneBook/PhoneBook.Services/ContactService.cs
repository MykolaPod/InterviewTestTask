using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DomainEntities;
using Contracts.Dto.Request;
using Contracts.Dto.Request.Contact;
using Contracts.Dto.Response;
using Contracts.Dto.Response.Contact;
using MediatR;
using PhoneBook.Services.Abstract;
using PhoneBook.Services.CQRSES.Queries;

namespace PhoneBook.Services
{
    public class ContactService : IContactService
    {
        private readonly IMediator _mediator;
        

        public ContactService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<PagedDto<ContactDetailsDto>> GetContacts(GetPagedItemsDto dto)
        {
            var query = new GetContactsQuery(dto);
            var result = await _mediator.Send(query);

            return result;
        }
    }
}