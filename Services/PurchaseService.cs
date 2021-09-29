using AutoMapper;
using MiraiSystem.Dtos;
using MiraiSystem.Models;
using MiraiSystem.Services.IServices;
using MiraiSystem.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PurchaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task InsertOrderAndOrderItem(TransactionDto transactionDto, OrderDto orderDto, List<OrderItemDto> orderItemDtos)
        {
            Order order = await AddOrder(orderDto);
            await AddOrderItemList(orderItemDtos, order);
            await UpdateShoesQuantity(orderItemDtos);
            await AddTransaction(transactionDto, orderDto);
            await unitOfWork.Commit();
        }

        private async Task AddTransaction(TransactionDto transactionDto, OrderDto orderDto)
        {
            transactionDto.OrderId = orderDto.Id;
            Transaction transaction = mapper.Map<Transaction>(transactionDto);
            await unitOfWork.TransactionRepository.Insert(transaction);
        }

        private async Task AddOrderItemList(List<OrderItemDto> orderItemDtos, Order order)
        {
            var orderItemEntities = mapper.Map<IEnumerable<OrderItem>>(orderItemDtos);
            foreach (var orderItem in orderItemEntities)
            {
                orderItem.OrderId = order.Id;
                await unitOfWork.OrderItemRepository.Insert(orderItem);
            }
        }

        private async Task UpdateShoesQuantity(List<OrderItemDto> orderItemDtos)
        {
            foreach (var orderItem in orderItemDtos)
            {
                Shoes shoes = await unitOfWork.ShoesRepository.GetById(orderItem.Sku);
                shoes.Quantity -= orderItem.Quantity;
                Console.WriteLine("this is quantity: " + shoes.Quantity);
                await unitOfWork.ShoesRepository.Update(shoes);
            }
        }

        private async Task<Order> AddOrder(OrderDto orderDto)
        {
            var order = mapper.Map<Order>(orderDto);
            await unitOfWork.OrderRepository.Insert(order);
            return order;
        }
    }
}
