﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VulcanizationAPI.Core.Entities;
using VulcanizationAPI.Core.Exceptions;
using VulcanizationAPI.Core.Models.Authentication;
using VulcanizationAPI.Core.Models.DTOs;
using VulcanizationAPI.Infrastructure.Data.Repositories.Abstract;
using VulcanizationAPI.Infrastructure.Services.Abstract;

namespace VulcanizationAPI.Infrastructure.Services.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IAccountRepository _accountRepository;

        public AccountService(IPasswordHasher<User> passwordHasher,
            AuthenticationSettings authenticationSettings,
            IAccountRepository accountRepository)
        {
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _accountRepository = accountRepository;
        }

        public async Task<string> GenerateJwt(LoginDto dto)
        {
            User user = await _accountRepository
                .FindSingleAsync(u => u.Email == dto.Email, u => u.Role);

            if (user is null)
            {
                throw new BadRequestException("Invalid username or password.");
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password.");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public async Task RegisterUser(RegisterUserDto dto)
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
            await _accountRepository.AddAsync(newUser);
        }
    }
}
