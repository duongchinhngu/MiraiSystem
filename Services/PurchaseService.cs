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

        public async Task InsertOrderAndOrderItem(OrderDto order, List<OrderItemDto> orderItemDtos)
        {
            Order orderEntity = await AddOrder(order);
            await AddOrderItemList(orderItemDtos, orderEntity);
            await UpdateShoesQuantity(orderItemDtos);
            await unitOfWork.Commit();
        }

        private async Task AddOrderItemList(List<OrderItemDto> orderItemDtos, Order orderEntity)
        {
            var orderItemEntities = mapper.Map<IEnumerable<OrderItem>>(orderItemDtos);
            foreach (var orderItem in orderItemEntities)
            {
                orderItem.OrderId = orderEntity.Id;
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

        private async Task<Order> AddOrder(OrderDto order)
        {
            var orderEntity = mapper.Map<Order>(order);
            await unitOfWork.OrderRepository.Insert(orderEntity);
            return orderEntity;
        }
    }
}
