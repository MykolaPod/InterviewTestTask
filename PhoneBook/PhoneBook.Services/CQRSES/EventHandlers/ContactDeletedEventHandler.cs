using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PhoneBook.Services.Abstract;
using PhoneBook.Services.CQRSES.Events;

namespace PhoneBook.Services.CQRSES.EventHandlers
{
    public class ContactDeletedEventHandler : INotificationHandler<ContactDeletedEvent>
    {
        private readonly ISignalRTransmitterService _signalRTransmitterService;

        public ContactDeletedEventHandler(ISignalRTransmitterService signalRTransmitterService)
        {
            _signalRTransmitterService = signalRTransmitterService;
        }

        public async Task Handle(ContactDeletedEvent notification, CancellationToken cancellationToken)
        {
           _ = _signalRTransmitterService.PublishContactDeletedEvent(notification.Dto, cancellationToken);

        }
    }
}