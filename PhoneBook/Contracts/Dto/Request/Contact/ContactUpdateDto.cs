using System;
using System.Collections.Generic;

namespace Contracts.Dto.Request.Contact
{
    public class ContactUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public List<ContactNumberUpdateDto> ContactNumbers { get; set; }
    }
}