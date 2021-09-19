using AutoMapper;
using MiraiSystem.Dtos;
using MiraiSystem.Helpers.FilterHelpers;
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
    public class ShoesService : IShoesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShoesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(ShoesDto dto)
        {
            var entity = _mapper.Map<Shoes>(dto);
            await _unitOfWork.ShoesRepository.Insert(entity);
            await _unitOfWork.Commit();
        }

        public Response<ShoesDto> Filter(ShoesFilter filter)
        {
            PagedList<Shoes> entities = _unitOfWork.ShoesRepository.Filter(filter);
            
            return new Response<ShoesDto>
            {
                TotalCount = entities.TotalCount,
                CurrentPage = entities.CurrentPage,
                TotalPages = entities.TotalPages,
                HasNext = entities.HasNext,
                HasPrevious = entities.HasPrevious,
                PageSize = entities.PageSize,
                Data = _mapper.Map<IEnumerable<ShoesDto>>(entities)
            };
        }

        public async Task<IEnumerable<ShoesDto>> GetAll()
        {
            var entities = await _unitOfWork.ShoesRepository.GetAll();
            return _mapper.Map<IEnumerable<ShoesDto>>(entities).ToList();
        }

        public async Task<ShoesDto> GetById(string id)
        {
            var entity = await _unitOfWork.ShoesRepository.GetById(id);
            return _mapper.Map<ShoesDto>(entity);
        }

        public async Task<IEnumerable<ShoesDto>> GetByModelCode(string modelCode)
        {
            var entities = await _unitOfWork.ShoesRepository.GetByModelCode(modelCode);
            return _mapper.Map<IEnumerable<ShoesDto>>(entities);
        }

        public async Task Remove(ShoesDto dto)
        {
            var entity = _mapper.Map<Shoes>(dto);
            await _unitOfWork.ShoesRepository.Delete(entity);
            await _unitOfWork.Commit();
        }

        public async Task Update(ShoesDto dto)
        {
            var entity = _mapper.Map<Shoes>(dto);
            await _unitOfWork.ShoesRepository.Update(entity);
            await _unitOfWork.Commit();
        }
    }
}
