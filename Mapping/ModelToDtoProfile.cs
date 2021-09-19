using AutoMapper;
using MiraiSystem.Dtos;
using MiraiSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Mapping
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Shoes, ShoesDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        }
    }
}
