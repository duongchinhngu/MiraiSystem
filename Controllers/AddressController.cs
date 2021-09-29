using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Dtos;
using MiraiSystem.Services.IServices;

namespace MiraiSystem.Controllers
{
    [Route("addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService service;

        public AddressController(IAddressService service)
        {
            this.service = service;
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetByUserId(string userId)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(userId))
                {
                    return BadRequest("UserId must be provided");
                }
                var addresses = await service.GetByUserID(userId);
                if( addresses != null && addresses.Any())
                {
                    return Ok(addresses);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
