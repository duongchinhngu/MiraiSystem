using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiraiSystem.Dtos;
using MiraiSystem.Helpers.FilterHelpers.UserFilters;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiraiSystem.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserDto>> GetByEmail(string email)
        {
            try
            {
                if (String.IsNullOrEmpty(email))
                {
                    return BadRequest("email must be provided");
                }
                var result = await _service.GetByEmail(email);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error: " + e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id))
                {
                    return BadRequest("Id must be provided");
                }
                var result = await _service.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error: " + e.Message);
            }

        }


        [HttpGet("result")]
        public ActionResult<Response<UserDto>> Filter([FromQuery] UserFilter filter)
        {
            try
            {
                if (filter == null)
                {
                    return BadRequest("User filter is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Filter has an invalid field");
                }
                var result = _service.Filter(filter);
                if (result != null || result.Data.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Inner exception: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("User is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("User has an invalid attribute");
                }

                await _service.Add(dto);
                return Created("", dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Inner error at " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UserDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(dto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
    }
}
