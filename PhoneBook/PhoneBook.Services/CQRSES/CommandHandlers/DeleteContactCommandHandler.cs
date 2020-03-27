using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Dto.Response.Contact;
using Data;
using Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.CQRSES.Commands;
using PhoneBook.Services.CQRSES.Events;

namespace PhoneBook.Services.CQRSES.CommandHandlers
{
    public class DeleteContactCommandHandler : BaseHandler, IRequestHandler<DeleteContactCommand, ContactDetailsDto>
    {
        public DeleteContactCommandHandler(ApplicationDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
        {
        }

        public async Task<ContactDetailsDto> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var dbEntity = await Context.Contacts.Include(c=>c.ContactNumbers)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (dbEntity == null)
            {
                throw new NotFoundEntityException();
            }

            var operationResult = Context.Contacts.Remove(dbEntity);
            await Context.SaveChangesAsync(cancellationToken);


            var result = Mapper.Map<ContactDetailsDto>(operationResult.Entity);

            _ = Mediator.Publish(new ContactDeletedEvent(result), cancellationToken);

            return result;

        }
    }
}