using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts.Dto.Response.Contact;
using Microsoft.AspNetCore.SignalR;
using PhoneBook.Services.Abstract;
using PhoneBook.Services.Hubs;

namespace PhoneBook.Services
{
    public class SignalRTransmitterService : ISignalRTransmitterService
    {
        private readonly IHubContext<ContactHub> _contactHub;

        public SignalRTransmitterService(IHubContext<ContactHub> contactHub)
        {
            _contactHub = contactHub ?? throw new ArgumentNullException(nameof(contactHub));
        }

        public Task PublishContactCreatedEvent(ContactDetailsDto contactDto, CancellationToken cancellationToken)
        {
            return _contactHub.Clients.All.SendAsync(nameof(ISignalRClient.ContactCreatedEvent), contactDto, cancellationToken);
        }

        public Task PublishContactUpdatedEvent(ContactDetailsDto contactDto, CancellationToken cancellationToken)
        {
            return _contactHub.Clients.All.SendAsync(nameof(ISignalRClient.ContactUpdatedEvent), contactDto, cancellationToken);
        }

        public Task PublishContactDeletedEvent(ContactDetailsDto contactDto, CancellationToken cancellationToken)
        {
            return _contactHub.Clients.All.SendAsync(nameof(ISignalRClient.ContactDeletedEvent), contactDto, cancellationToken);
        }
    }
}
