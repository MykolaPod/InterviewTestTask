using System;
using System.Collections.Generic;

namespace Contracts.Dto.Response.Contact
{
    public class ContactDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public List<ContactNumberDetailsDto> ContactNumbers { get; set; }
    }
}