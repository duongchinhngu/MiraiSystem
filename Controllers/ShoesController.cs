using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Dtos;
using MiraiSystem.Helpers.FilterHelpers;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Models;
using MiraiSystem.Services.IServices;
using AutoMapper;
using MiraiSystem.Repositories;

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

        [HttpGet("item")]
        public ActionResult<Response<ShoesDto>> Filter([FromQuery] ShoesFilter filter)
        {
            try
            {
                var result = _service.Filter(filter);
                if (result.Data.Any())
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoesDto>> Get(string id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task Post(ShoesDto dto)
        {
            await _service.Add(dto);
            NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string sku, ShoesDto dto)
        {
            if (sku != dto.Sku)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(dto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.GetById(sku) == null)
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
