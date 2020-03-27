using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PhoneBook.Services.Abstract;
using PhoneBook.Services.CQRSES.Events;

namespace PhoneBook.Services.CQRSES.EventHandlers
{
    public class ContactCreatedEventHandler : INotificationHandler<ContactCreatedEvent>
    {
        private readonly ISignalRTransmitterService _signalRTransmitterService;

        public ContactCreatedEventHandler(ISignalRTransmitterService signalRTransmitterService)
        {
            _signalRTransmitterService = signalRTransmitterService ?? throw new ArgumentNullException(nameof(signalRTransmitterService));
        }

        public async Task Handle(ContactCreatedEvent notification, CancellationToken cancellationToken)
        {
            _ = _signalRTransmitterService.PublishContactCreatedEvent(notification.ContactDto, cancellationToken);
        }
    }
}