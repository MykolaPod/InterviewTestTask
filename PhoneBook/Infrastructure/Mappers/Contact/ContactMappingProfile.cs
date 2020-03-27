using System.Collections.Generic;
using AutoMapper;
using Contracts.DomainEntities;
using Contracts.Dto.Response.Contact;

namespace Infrastructure.Mappers.Contact
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<ContactNumber, ContactNumberDetailsDto>();
            CreateMap<Contracts.DomainEntities.Contact, ContactDetailsDto>();
        }
    }
}