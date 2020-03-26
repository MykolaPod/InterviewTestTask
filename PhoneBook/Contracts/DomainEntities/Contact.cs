using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contracts.DomainEntities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Address { get; set; }
        public List<ContactNumber> ContactNumbers { get; set; }
    }
}