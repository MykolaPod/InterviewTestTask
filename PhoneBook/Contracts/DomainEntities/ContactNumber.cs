using System.ComponentModel.DataAnnotations;

namespace Contracts.DomainEntities
{
    public class ContactNumber
    {
        [Key]
        public int Id { get; set; }

        public int ContactId { get; set; }

        public string Number { get; set; }
    }
}