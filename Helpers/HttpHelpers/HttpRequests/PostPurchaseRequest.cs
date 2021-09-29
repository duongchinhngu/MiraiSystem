using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.Parameters
{
    public class PostPurchaseRequest
    {
        public TransactionDto Transaction { get; set; }

        public OrderDto Order { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }
}
