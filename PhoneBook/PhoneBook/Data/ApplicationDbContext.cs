using Contracts.DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ContactNumber> ContactNumbers { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}