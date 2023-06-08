using Microsoft.IdentityModel.Tokens;
using ManningApi.Models;
using ManningApi.Repositories.Interfaces;
using ManningApi.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManningApi.Services
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
        public void ClockOperatorOut(int sessionID) => _clockInRepository.ClockOperatorOut(sessionID);

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
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            Console.WriteLine($"Issuer: {_configuration["Jwt:Issuer"]}");
            Console.WriteLine($"Audience: {_configuration["Jwt:Audience"]}");
            Console.WriteLine($"Key: {_configuration["Jwt:Key"]}");
            Console.WriteLine($"ExpireDays: {_configuration["Jwt:ExpireDays"]}");

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
