using AutoMapper;
using MiraiSystem.Dtos;
using MiraiSystem.Helpers.PagingHelpers;
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
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<PagedList<Shoes>, Response<ShoesDto>>()
                .ForMember( dest => dest.CurrentPage, opt => opt.MapFrom( src => src.CurrentPage))
                .ForMember( dest => dest.HasNext, opt => opt.MapFrom( src => src.HasNext))
                .ForMember( dest => dest.HasPrevious, opt => opt.MapFrom( src => src.HasPrevious))
                .ForMember( dest => dest.PageSize, opt => opt.MapFrom( src => src.PageSize))
                .ForMember( dest => dest.TotalCount, opt => opt.MapFrom( src => src.TotalCount))
                .ForMember( dest => dest.TotalPages, opt => opt.MapFrom( src => src.TotalPages))
                .ForMember( dest => dest.Data, opt => opt.MapFrom( src => src.AsEnumerable()))
                .ReverseMap();
            CreateMap<PagedList<User>, Response<UserDto>>()
                .ForMember(dest => dest.CurrentPage, opt => opt.MapFrom(src => src.CurrentPage))
                .ForMember(dest => dest.HasNext, opt => opt.MapFrom(src => src.HasNext))
                .ForMember(dest => dest.HasPrevious, opt => opt.MapFrom(src => src.HasPrevious))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
                .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.AsEnumerable()))
                .ReverseMap();
        }
    }
}
