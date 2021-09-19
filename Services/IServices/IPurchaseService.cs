using MiraiSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Services.IServices
{
    public interface IPurchaseService
    {
        Task InsertOrderAndOrderItem(OrderDto order, List<OrderItemDto> orderItemDtos);
    }
}
