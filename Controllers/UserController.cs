using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiraiSystem.Dtos;
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
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _service.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(string id)
        {
            return await _service.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async void Post(UserDto dto)
        {
            await _service.Add(dto);
            NoContent();
        }

        // PUT api/<UserController>/5
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
