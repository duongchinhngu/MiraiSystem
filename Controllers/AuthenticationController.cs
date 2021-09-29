using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MiraiSystem.Services.IServices;

namespace MiraiSystem.Controllers
{
    [Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthenticationController(IAuthService service)
        {
            this.service = service;
        }

        [HttpGet("sign-in")]
        public ActionResult<SecurityToken> Authenticate([FromQuery] string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return BadRequest("EMail must be provided");
            }

            var token = service.Authenticate(email);

            if (token == null)
            {
                return BadRequest("invalid email");
            }

            return Ok(token);
        }
    }
}
