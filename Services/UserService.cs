using AutoMapper;
using MiraiSystem.Dtos;
using MiraiSystem.Helpers.FilterHelpers.UserFilters;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Models;
using MiraiSystem.Services.IServices;
using MiraiSystem.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(UserDto dto)
        {
            var entity = _mapper.Map<User>(dto);
            await _unitOfWork.UserRepository.Insert(entity);
            await _unitOfWork.Commit();
        }

        public Response<UserDto> Filter(UserFilter filter)
        {
            var entities = _unitOfWork.UserRepository.Filter(filter);
            return _mapper.Map<Response<UserDto>>(entities);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var entities = await _unitOfWork.UserRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(entities).ToList();
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var entity = await _unitOfWork.UserRepository.GetByEmail(email);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDto> GetById(string id)
        {
            var entity = await _unitOfWork.UserRepository.GetById(id);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task Remove(UserDto dto)
        {
            var entity = _mapper.Map<User>(dto);
            await _unitOfWork.UserRepository.Delete(entity);
            await _unitOfWork.Commit();
        }

        public async Task Update(UserDto dto)
        {
            var entity = _mapper.Map<User>(dto);
            await _unitOfWork.UserRepository.Update(entity);
            await _unitOfWork.Commit();
        }
    }
}

