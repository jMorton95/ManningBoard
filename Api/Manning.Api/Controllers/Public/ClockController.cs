using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models;
using Manning.Api.Services.Interfaces;
using Manning.Api.Models.DataTransferObjects;
using Microsoft.IdentityModel.Tokens;

namespace Manning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClockController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public ClockController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("{clockCardNumber}")]
        public async Task<ActionResult<ClockedInOperatorDTO>> ValidateClockCardNumber(int clockCardNumber)
        {
            if (_loginService.ClockCardIsInvalid(clockCardNumber))
            {
                return BadRequest("Clock Card must be 6 digits");
            }

            Operator? op = await _loginService.CheckClockCardAsync(clockCardNumber);

            if (op == null)
            {
                return BadRequest("Invalid Clock Card Number.");
            }

            int sessionId = await _loginService.ClockOperatorIn(op);
            string jwt = _loginService.GenerateJwtToken(op);

            ClockedInOperatorDTO validatedOperator = new(op, sessionId);

            Response.Headers.Append("JWT", jwt);

            return Ok(validatedOperator);
        }

        [HttpPost]
        public async Task<ActionResult> ClockOutOperator(int sessionId)
        {
            var msg = new { message = $"Clocked Out Session - {sessionId}" };
            await _loginService.ClockOperatorOut(sessionId);
            return Ok(msg);
        }


        [HttpGet("GetOperatorFromJWT")]
        public async Task<ActionResult<ClockedInOperatorDTO>> GetOperatorFromJWT(string jwt)
        {
            //TODO: Refactor
            ClockModel? clockedOperator = await _loginService.TryGetClockInFromJWT(jwt);

            if (clockedOperator == null)
            {
                return BadRequest("Not Valid");
            }

            Operator? op = await _loginService.CheckClockCardAsync(clockedOperator.ClockCardNumber);

            if (op == null)
            {
                return BadRequest("Operator Not Valid");
            }

            int sessionId = await _loginService.ClockOperatorIn(op);

            ClockedInOperatorDTO validatedOperator = new(op, sessionId);

            return Ok(validatedOperator);
        }

    }
}