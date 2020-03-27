using Contracts.Dto.Request.Contact;
using Contracts.Dto.Response.Contact;
using MediatR;

namespace PhoneBook.Services.CQRSES.Commands
{
    public class UpdateContactCommand : IRequest<ContactDetailsDto>
    {
        public ContactUpdateDto Dto { get; }

        public UpdateContactCommand(ContactUpdateDto dto)
        {
            Dto = dto;
        }
    }
}