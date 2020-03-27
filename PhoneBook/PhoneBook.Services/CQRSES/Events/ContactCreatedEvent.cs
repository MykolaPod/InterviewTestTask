using Contracts.Dto.Response.Contact;
using MediatR;

namespace PhoneBook.Services.CQRSES.Events
{
    public class ContactCreatedEvent : INotification
    {
        public ContactDetailsDto ContactDto { get; }

        public ContactCreatedEvent(ContactDetailsDto contactDto)
        {
            ContactDto = contactDto;
        }
    }
}