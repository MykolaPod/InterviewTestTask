using System.Threading.Tasks;

namespace PhoneBook.Services.Abstract
{

    public interface ISignalRClient
    {
        Task ContactCreatedEvent(string dtoJson);
    }
}