using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DomainEntities;

namespace PhoneBook.Data.SeedData
{
    public class ApplicationDbContextSeed
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextSeed(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SeedAsync()
        {
            try
            {
                await SeedContacts();

            }
            catch (Exception ex)
            {
                ;
            }
        }

        private async Task SeedContacts()
        {
            var contacts = new List<Contact>()
            {
                new Contact()
                {
                    Name = "Adele",
                    Address = "Brooklyn",
                    BirthDate = DateTime.UtcNow.AddYears(-30).Date,
                    ContactNumbers = new List<ContactNumber>()
                    {
                        new ContactNumber() {Number = "111111111"},
                        new ContactNumber() {Number = "111112222222222"}
                    }
                },
                new Contact()
                {
                    Name = "August",
                    Address = "Rome",
                    BirthDate = DateTime.UtcNow.AddYears(-50).AddDays(-1 * new Random().Next(30, 70)).Date,
                    ContactNumbers = new List<ContactNumber>()
                    {
                        new ContactNumber() {Number = "2222222222"},
                        new ContactNumber() {Number = "22222222243212356"}
                    }
                }
            };

            foreach (var contact in contacts)
            {
                _context.Add(contact);
            }

            await _context.SaveChangesAsync();
        }
    }
}