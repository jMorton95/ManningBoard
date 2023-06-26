using Microsoft.IdentityModel.Tokens;
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

        public async Task<ClockModel>? TryGetClockInFromJWT(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
                ValidateIssuer = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = _configuration["Jwt:Audience"]
            };

            SecurityToken validatedToken;

            try
            {
                handler.ValidateToken(jwtToken, validationParameters, out validatedToken);
            }
            catch (Exception ex)
            {
                //TODO: Logging.
                return null;
            }

            DateTime validTo = validatedToken.ValidTo;

            if (validTo < DateTime.Now)
            {
                Console.WriteLine(validTo.ToString());
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine("Hit this");
                return null;
            }

            var securityToken = validatedToken as JwtSecurityToken;

            string sub = securityToken.Claims.First(claim => claim.Type == "sub").Value;

            bool clockCardResult = int.TryParse(sub, out int clockCard);

            if (!clockCardResult)
            {
                return null;
            }

            var clockedOperator = await _clockInRepository.GetClockedInOperator(clockCard);

            if (clockedOperator == null)
            {
                return null;
            }

            return clockedOperator;
        }
    }
}
