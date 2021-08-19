using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiraiSystem.Dtos;
using MiraiSystem.Dtos.ExtendedDtos;
using MiraiSystem.Helpers.FilterHelpers;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiraiSystem.Controllers
{
    [Route("shoes")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        private readonly IShoesService _service;
        public ShoesController(IShoesService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<ShoesDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("filter")]
        public async Task<ActionResult<Response<ExtendedConcreteShoesDto>>> GetAll([FromQuery] ShoesFilter filter)
        {
            try
            {
                var result = await _service.Filter(filter);
                if(result.Data.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ShoesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoesDto>> Get(string id)
        {
            return await _service.GetById(id);
        }

        // POST api/<ShoesController>
        [HttpPost]
        public async void Post(ShoesDto dto)
        {
            await _service.Add(dto);
            NoContent();
        }

        // PUT api/<ShoesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ShoesDto dto)
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
