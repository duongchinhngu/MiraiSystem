using AutoMapper;
using MiraiSystem.Dtos;
using MiraiSystem.Dtos.ExtendedDtos;
using MiraiSystem.Models;
using MiraiSystem.Models.ExtendedModels;
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
            CreateMap<Shoes, ShoesDto>().ReverseMap();
            CreateMap<ConcreteShoes, ConcreteShoesDto>().ReverseMap();
            CreateMap<ShoesImage, ShoesImageDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<ExtendedConcreteShoes, ExtendedConcreteShoesDto>().ReverseMap();
        }
    }
}
