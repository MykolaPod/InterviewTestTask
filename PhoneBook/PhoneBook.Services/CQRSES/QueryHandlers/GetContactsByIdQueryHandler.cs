using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Dto.Response.Contact;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.CQRSES.Queries;

namespace PhoneBook.Services.CQRSES.QueryHandlers
{
    public class GetContactsByIdQueryHandler : BaseHandler, IRequestHandler<GetContactsByIdQuery, ContactDetailsDto>
    {
        public GetContactsByIdQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ContactDetailsDto> Handle(GetContactsByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await Context.Contacts
                .Include(c => c.ContactNumbers)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            return Mapper.Map<ContactDetailsDto>(result);
        }

        
    }
}