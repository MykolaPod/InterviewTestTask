using System.Threading;
using System.Threading.Tasks;
using Contracts.Dto.Response.Contact;

namespace PhoneBook.Services.Abstract
{
    public interface ISignalRTransmitterService
    {
        Task PublishContactCreatedEvent(ContactDetailsDto contactDto, CancellationToken cancellationToken);
        Task PublishContactUpdatedEvent(ContactDetailsDto notificationDto, CancellationToken cancellationToken);
    }
}