using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Entities;

namespace VulcanizationAPI
{
    public class VulcanizationSeeder
    {
        private readonly VulcanizationDbContext _dbContext;

        public VulcanizationSeeder(VulcanizationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Contacts.Any())
                {
                    var contacts = GetContacts();
                    _dbContext.AddRange(contacts);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Addresses.Any())
                {
                    var addresses = GetAddresses();
                    _dbContext.AddRange(addresses);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Vulcanizations.Any())
                {
                    var vulcanizations = GetVulcanizations();
                    _dbContext.AddRange(vulcanizations);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Contact> GetContacts()
        {
            var contacts = new List<Contact>()
            {
                new Contact()
                {
                    Email = "Dario@gmail.com",
                    PhoneNumber = "333222111"
                },
                new Contact()
                {
                    Email = "Mario@gmail.com",
                    PhoneNumber = "111222333"
                }
            };
            return contacts;
        }
        private IEnumerable<Address> GetAddresses()
        {
            var addresses = new List<Address>()
            {
                new Address()
                {
                    City = "Warsaw",
                    Street = "Domowa",
                    PostalCode = "00-002"
                },
                new Address()
                {
                    City = "Prague",
                    Street = "Highcastle",
                    PostalCode = "100-00"
                }
            };
            return addresses;
        }
        private IEnumerable<Vulcanization> GetVulcanizations()
        {
            var vulcanizations = new List<Vulcanization>()
            {
                new Vulcanization()
                {
                    Name = "Dario Vulcanization",
                    Description = "Hello its me",
                    AddressId = 1,
                    ContactId = 1

                },
                new Vulcanization()
                {
                    Name = "Mario Vulcanization",
                    Description = "Hello there",
                    AddressId = 2,
                    ContactId = 2
                }
            };
            return vulcanizations;
        }

    }
}

