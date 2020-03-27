using Contracts.Dto.Request.Contact;
using Contracts.Dto.Response.Contact;
using MediatR;

namespace PhoneBook.Services.CQRSES.Commands
{
    public class CreateContactCommand : IRequest<ContactDetailsDto>
    {
        public ContactCreateDto Dto { get; }

        public CreateContactCommand(ContactCreateDto dto)
        {
            Dto = dto;
        }
    }
}