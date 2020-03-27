using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DomainEntities;
using Contracts.Dto.Response;
using Contracts.Dto.Response.Contact;
using Data;
using Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.CQRSES.Queries;

namespace PhoneBook.Services.CQRSES.QueryHandlers
{
    public class GetContactsQueryHandler : BaseHandler, IRequestHandler<GetContactsQuery, PagedDto<ContactDetailsDto>>
    {
        
        public GetContactsQueryHandler(ApplicationDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
        {
        }

        public async Task<PagedDto<ContactDetailsDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var result = await Context.Contacts
                .Include(c => c.ContactNumbers)
                .GetPagedResultOf<Contact, ContactDetailsDto>(request.Dto, Mapper, cancellationToken);

            return result;

        }
    }
}