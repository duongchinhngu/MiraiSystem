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
    [Route("concrete-shoes")]
    [ApiController]
    public class ConcreteShoesController : ControllerBase
    {
        private readonly IConcreteShoesService _service;
        public ConcreteShoesController(IConcreteShoesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ConcreteShoesDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConcreteShoesDto>> Get(string id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async void Post(ConcreteShoesDto dto)
        {
            await _service.Add(dto);
            NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ConcreteShoesDto dto)
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
