using Microsoft.AspNetCore.Identity;
using VulcanizationAPI.Core.Entities;
using VulcanizationAPI.Core.Entities.Concrete;

namespace VulcanizationAPI.Infrastructure.Data
{
    public class VulcanizationSeeder
    {
        private readonly VulcanizationDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public VulcanizationSeeder(VulcanizationDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
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
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.AddRange(users);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Services.Any())
                {
                    var services = GetServices();
                    _dbContext.AddRange(services);
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
                    Email = "Vulcanization1@gmail.com",
                    PhoneNumber = "888888888"
                },
                new Contact()
                {
                    Email = "Vulcanization2@gmail.com",
                    PhoneNumber = "+48321321321"
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
                    City = "Warszawa",
                    Street = "Domowa",
                    PostalCode = "00-002"
                },
                new Address()
                {
                    City = "Rzeszów",
                    Street = "Dąbrowskiego",
                    PostalCode = "35-036"
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
                    Name = "First Vulcanization",
                    Description = "First exemplary vulcanization",
                    AddressId = 1,
                    ContactId = 2

                },
                new Vulcanization()
                {
                    Name = "Second Vulcanization",
                    Description = "Second examplary vulcanization",
                    AddressId = 2,
                    ContactId = 1
                }
            };
            return vulcanizations;
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Employee"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };
            return roles;
        }
        private IEnumerable<User> GetUsers()
        {
            var admin = new User()
            {
                Email = "admin@admin.pl",
                FirstName = "Admin",
                LastName = "Adminowski",
                RoleId = 3
            };
            admin.PasswordHash = _passwordHasher.HashPassword(admin, "Haslo123");

            var employee = new User()
            {
                Email = "employee@employee.pl",
                FirstName = "Employee",
                LastName = "Marks",
                RoleId = 2
            };
            employee.PasswordHash = _passwordHasher.HashPassword(employee, "Haslo123");

            var user = new User()
            {
                Email = "user@user.pl",
                FirstName = "Userus",
                LastName = "Markos",
                RoleId = 1
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, "Haslo123");

            var users = new List<User>() { admin, employee, user };
            return users;
        }
        private IEnumerable<Service> GetServices()
        {
            var services = new List<Service>()
            {
                new Service()
                {
                    Name = "wymiana opon",
                    Description = "Powinna obejmować także ewentualną wymianę tzw. zaworków, " +
                                    "które po sezonie ulegają przegrzaniu i spękaniu, przez co zaczynają stanowić zagrożenie w czasie jazdy",
                    Price = 70,
                    VulcanizationId = 1
                },
                new Service()
                {
                    Name = "wyważanie kół",
                    Description = "Pozwala uniknąć niekorzystnych drgań, przedwczesnego i nieregularnego " +
                                    "zużywania się opon oraz nadmiernego zużywania się elementów zawieszenia samochodu",
                    Price = 40,
                    VulcanizationId = 1
                },
                new Service()
                {
                    Name = "pompowanie opon",
                    Description = "Jest ważne głównie dlatego, że zbyt wysokie lub zbyt niskie ciśnienie może powodować szybkie zużycie ogumienia",
                    Price = 34,
                    VulcanizationId = 1
                },
                new Service()
                {
                    Name = "pompowanie opon",
                    Description = "Jest ważne głównie dlatego, że zbyt wysokie lub zbyt niskie ciśnienie może powodować szybkie zużycie ogumienia",
                    Price = 30,
                    VulcanizationId = 2
                },
                new Service()
                {
                    Name = "naprawa ogumienia",
                    Description ="dętkowe i bezdętkowe",
                    Price = 70,
                    VulcanizationId = 2

                }
            };
            return services;
        }
    }
}

