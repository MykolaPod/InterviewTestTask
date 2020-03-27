using Contracts.Dto.Response.Contact;
using MediatR;

namespace PhoneBook.Services.CQRSES.Events
{
    public class ContactDeletedEvent : INotification
    {
        public ContactDetailsDto Dto { get; }

        public ContactDeletedEvent(ContactDetailsDto dto)
        {
            Dto = dto;
        }
    }
}