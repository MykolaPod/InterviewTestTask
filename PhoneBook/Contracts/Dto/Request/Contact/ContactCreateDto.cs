using System;
using System.Collections.Generic;

namespace Contracts.Dto.Request.Contact
{
    public class ContactCreateDto
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public List<ContactNumberCreateDto> ContactNumbers { get; set; }
    }
}