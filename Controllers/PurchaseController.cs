using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Dtos;
using MiraiSystem.Helpers.Parameters;
using MiraiSystem.Services.IServices;

namespace MiraiSystem.Controllers
{
    [Route("purchase")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _service;
        public PurchaseController(IPurchaseService service)
        {
            _service = service;
        }

        //[FromQuery] TransactionDto transactionDto,[FromQuery] OrderDto orderDto, [FromBody] List<OrderItemDto> orderItemDtos
        [HttpPost]
        public async Task<IActionResult> Post(PostPurchaseRequest parameters)
        {
            TransactionDto transactionDto = parameters.Transaction;
            OrderDto orderDto = parameters.Order;
            List<OrderItemDto> orderItemDtos = parameters.OrderItems;
            try
            {
                if (orderDto == null)
                {
                    return BadRequest("order object is null");
                }
                if (orderItemDtos == null || orderItemDtos.Count() == 0)
                {
                    return BadRequest("order item list object is null or empty");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("There is an invalid model object attribute");
                }
                await _service.InsertOrderAndOrderItem(transactionDto, orderDto, orderItemDtos);
                return Created("", orderDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }


        }
    }
}
