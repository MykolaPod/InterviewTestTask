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
    public class UpdateContactCommandHandler : BaseHandler, IRequestHandler<UpdateContactCommand, ContactDetailsDto>
    {
        public UpdateContactCommandHandler(ApplicationDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
        {
        }

        public async Task<ContactDetailsDto> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var dbEntity = await Context.Contacts.Include(c=>c.ContactNumbers)
                .FirstOrDefaultAsync(c => c.Id == request.Dto.Id, cancellationToken);

            if (dbEntity == null)
            {
                throw new NotFoundEntityException();
            }

            Mapper.Map(request.Dto, dbEntity);

            Context.Contacts.Update(dbEntity);
            await Context.SaveChangesAsync(cancellationToken);

            var result = Mapper.Map<ContactDetailsDto>(dbEntity);
            _ = Mediator.Publish(new ContactUpdatedEvent(result), cancellationToken);


            return result;

        }
    }
}