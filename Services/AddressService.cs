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
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task Add(AddressDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AddressDto> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AddressDto>> GetByUserID(string userId)
        {
            var entities = await unitOfWork.AddressRepository.GetByUserID(userId);
            return mapper.Map<IEnumerable<AddressDto>>(entities);
        }

        public Task Remove(AddressDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Update(AddressDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
