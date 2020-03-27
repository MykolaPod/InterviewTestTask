using Contracts.Dto.Response.Contact;
using MediatR;

namespace PhoneBook.Services.CQRSES.Queries
{
    public class GetContactsByIdQuery : IRequest<ContactDetailsDto>
    {
        public int Id { get;  }

        public GetContactsByIdQuery(int id)
        {
            Id = id;
        }
    }
}