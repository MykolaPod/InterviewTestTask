using Contracts.Dto.Response.Contact;
using MediatR;

namespace PhoneBook.Services.CQRSES.Events
{
    public class ContactUpdatedEvent : INotification
    {
        public ContactDetailsDto Dto { get; }

        public ContactUpdatedEvent(ContactDetailsDto dto)
        {
            Dto = dto;
        }
    }
}