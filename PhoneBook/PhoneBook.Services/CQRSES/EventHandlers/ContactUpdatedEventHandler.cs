using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PhoneBook.Services.Abstract;
using PhoneBook.Services.CQRSES.Events;

namespace PhoneBook.Services.CQRSES.EventHandlers
{
    public class ContactUpdatedEventHandler : INotificationHandler<ContactUpdatedEvent>
    {
        private readonly ISignalRTransmitterService _signalRTransmitterService;

        public ContactUpdatedEventHandler(ISignalRTransmitterService signalRTransmitterService)
        {
            _signalRTransmitterService = signalRTransmitterService ?? throw new ArgumentNullException(nameof(signalRTransmitterService));
        }

        public async Task Handle(ContactUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _ = _signalRTransmitterService.PublishContactUpdatedEvent(notification.Dto, cancellationToken);
        }
    }
}