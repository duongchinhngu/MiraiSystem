using AutoMapper;
using MiraiSystem.Dtos;
using MiraiSystem.Dtos.ExtendedDtos;
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

        public async Task<Response<ExtendedConcreteShoesDto>> Filter(ShoesFilter filter)
        {
            var entities = await _unitOfWork.ShoesRepository.Filter(filter);
            return new Response<ExtendedConcreteShoesDto>
            {
                TotalCount = entities.TotalCount,
                CurrentPage = entities.CurrentPage,
                TotalPages = entities.TotalPages,
                HasNext = entities.HasNext,
                HasPrevious = entities.HasPrevious,
                PageSize = entities.PageSize,
                Data = entities.Select(s => new ExtendedConcreteShoesDto
                {
                    Gender = s.Gender,
                    Id = s.Id,
                    MainImageUrl = s.MainImageUrl,
                    Price = s.Price,
                    Quantity = s.Quantity,
                    ShoesId = s.ShoesId,
                    ShoesName = s.ShoesName,
                    Size = s.Size,
                }).ToList()
            };
        }

        public async Task<IEnumerable<ShoesDto>> GetAll()
        {
            var entities = await _unitOfWork.ShoesRepository.GetAll();
            return _mapper.Map<IEnumerable<ShoesDto>>(entities).ToList();
        }

        public Task<ShoesDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ShoesDto> GetById(string id)
        {
            var entity = await _unitOfWork.ShoesRepository.GetById(id);
            return _mapper.Map<ShoesDto>(entity);
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
