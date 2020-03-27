using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DomainEntities;
using Contracts.Dto.Response.Contact;
using Data;
using MediatR;
using PhoneBook.Services.CQRSES.Commands;
using PhoneBook.Services.CQRSES.Events;

namespace PhoneBook.Services.CQRSES.CommandHandlers
{
    public class CreateContactCommandHandler : BaseHandler, IRequestHandler<CreateContactCommand, ContactDetailsDto>
    {
        public CreateContactCommandHandler(ApplicationDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
        {
        }

        public async Task<ContactDetailsDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = Mapper.Map<Contact>(request.Dto);

            var operationResult = await Context.Contacts.AddAsync(contact, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);

            var result = Mapper.Map<ContactDetailsDto>(operationResult.Entity);

            _ = Mediator.Publish(new ContactCreatedEvent(result), cancellationToken);

            return result;
        }
    }
}