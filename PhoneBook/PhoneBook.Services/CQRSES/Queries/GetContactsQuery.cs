using Contracts.Dto.Request;
using Contracts.Dto.Response;
using Contracts.Dto.Response.Contact;
using MediatR;

namespace PhoneBook.Services.CQRSES.Queries
{
    public class GetContactsQuery : IRequest<PagedDto<ContactDetailsDto>>
    {
        public GetPagedItemsDto Dto { get; }

        public GetContactsQuery(GetPagedItemsDto dto)
        {
            Dto = dto;
        }
    }
}