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
    [Route("product-images")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _service;
        public ProductImageController(IProductImageService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductImageDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductImageDto>> Get(string id)
        {
            return await _service.GetById(id);
        }

        [HttpGet("products/{sku}")]
        public async Task<ActionResult<IEnumerable<ProductImageDto>>> GetByModel(string sku)
        {
            if (String.IsNullOrEmpty(sku))
            {
                return BadRequest();
            }
            var dtos = await _service.GetBySku(sku);
            if (dtos == null)
            {
                return NotFound();
            }
            return Ok(dtos);
        }

        [HttpPost]
        public async Task Post(ProductImageDto dto)
        {
            await _service.Add(dto);
            NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ProductImageDto dto)
        {
            if (id != dto.ImageId)
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
