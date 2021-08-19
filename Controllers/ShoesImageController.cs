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
    [Route("shoes-images")]
    [ApiController]
    public class ShoesImageController : ControllerBase
    {
        private readonly IShoesImageService _service;
        public ShoesImageController(IShoesImageService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<ShoesImageDto>> GetAll()
        {
            return await _service.GetAll();
        }

        // GET api/<ShoesImageController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoesImageDto>> Get(string id)
        {
            return await _service.GetById(id);
        }

        // POST api/<ShoesImageController>
        [HttpPost]
        public async void Post(ShoesImageDto dto)
        {
            await _service.Add(dto);
            NoContent();
        }

        // PUT api/<ShoesImageController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ShoesImageDto dto)
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
