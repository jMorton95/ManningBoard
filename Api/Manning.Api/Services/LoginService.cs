﻿using Microsoft.IdentityModel.Tokens;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Manning.Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly IClockInRepository _clockInRepository;
        private readonly IConfiguration _configuration;
        public LoginService(IClockInRepository clockInRepository, IConfiguration configuration)
        {
            _clockInRepository = clockInRepository;
            _configuration = configuration;
        }

        public bool ClockCardIsInvalid(int clockCardNumber)
        {
            if (clockCardNumber.ToString().Length != 6)
            {
                return true;
            }

            return false;
        }

        public async Task<Operator?> CheckClockCardAsync(int clockCardNumber)
        {
            return await _clockInRepository.CheckClockCardAsync(clockCardNumber);
        }

        public async Task<int> ClockOperatorIn(Operator op) => await _clockInRepository.ClockOperatorIn(op);
        public async Task ClockOperatorOut(int sessionID) => await _clockInRepository.ClockOperatorOut(sessionID);

        public string GenerateJwtToken(Operator op)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, op.ClockCardNumber.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            if (op.IsAdministrator)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
