using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using ManningApi.Models;
using ManningApi.Services.Interfaces;
using ManningApi.ViewModels;

namespace ManningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("{clockCardNumber}")]
        public async Task<ActionResult<ClockedInOperator>> ValidateClockCardNumber(int clockCardNumber)
        {
            if (_loginService.ClockCardIsInvalid(clockCardNumber))
            {
                return BadRequest("Clock Card must be 6 digits");
            }

            Operator? op = await _loginService.CheckClockCardAsync(clockCardNumber);

            if (op == null)
            {
                return Unauthorized("Invalid Clock Card Number.");
            }

            ClockedInOperator validatedOperator = new(op, _loginService.GenerateJwtToken(op));

            return Ok(validatedOperator);
        }

    }
}