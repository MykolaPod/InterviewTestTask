using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Dto.Response.Contact;
using Data;
using Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.CQRSES.Queries;

namespace PhoneBook.Services.CQRSES.QueryHandlers
{
    public class GetContactsByIdQueryHandler : BaseHandler, IRequestHandler<GetContactsByIdQuery, ContactDetailsDto>
    {
        public GetContactsByIdQueryHandler(ApplicationDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
        {
        }

        public async Task<ContactDetailsDto> Handle(GetContactsByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await Context.Contacts
                .Include(c => c.ContactNumbers)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (result == null)
            {
                throw new NotFoundEntityException();
            }

            return Mapper.Map<ContactDetailsDto>(result);
        }

        
    }
}