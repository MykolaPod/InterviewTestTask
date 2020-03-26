using PhoneBook.Services.Abstract;
using Microsoft.AspNetCore.SignalR;
namespace PhoneBook.Services.Hubs
{
    public class ContactHub : Hub<ISignalRClient>
    {
        
    }
}