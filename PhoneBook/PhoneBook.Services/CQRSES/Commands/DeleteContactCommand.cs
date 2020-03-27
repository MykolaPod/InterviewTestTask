using Contracts.Dto.Response.Contact;
using MediatR;

namespace PhoneBook.Services.CQRSES.Commands
{
    public class DeleteContactCommand : IRequest<ContactDetailsDto>
    {
        public int Id { get; }

        public DeleteContactCommand(in int id)
        {
            Id = id;
        }
    }
}