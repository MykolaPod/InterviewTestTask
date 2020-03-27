using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DomainEntities;
using Contracts.Dto.Response.Contact;
using Data;
using MediatR;
using PhoneBook.Services.CQRSES.Commands;

namespace PhoneBook.Services.CQRSES.CommandHandlers
{
    public class CreateContactCommandHandler : BaseHandler, IRequestHandler<CreateContactCommand, ContactDetailsDto>
    {
        public CreateContactCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ContactDetailsDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = Mapper.Map<Contact>(request.Dto);

            var result = await Context.Contacts.AddAsync(contact, cancellationToken);

            await Context.SaveChangesAsync(cancellationToken);
            return Mapper.Map<ContactDetailsDto>(result.Entity);
        }
    }
}