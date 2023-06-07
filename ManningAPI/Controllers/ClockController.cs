﻿using Microsoft.AspNetCore.Mvc;
using ManningApi.Models;
using ManningApi.Services.Interfaces;
using ManningApi.ViewModels;

namespace ManningApi.Controllers
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
        public async Task<ActionResult<ClockedInOperator>> ValidateClockCardNumber(int clockCardNumber)
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

            ClockedInOperator validatedOperator = new(op, _loginService.GenerateJwtToken(op), sessionId);

            return Ok(validatedOperator);
        }

        [HttpPost]
        public ActionResult ClockOutOperator(int sessionId)
        {
            _loginService.ClockOperatorOut(sessionId);
            return Ok();
        }

    }
}