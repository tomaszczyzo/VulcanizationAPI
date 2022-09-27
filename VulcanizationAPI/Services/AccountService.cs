using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Entities;
using VulcanizationAPI.Models;

namespace VulcanizationAPI.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly VulcanizationDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(VulcanizationDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                RoleId = dto.RoleId
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}
