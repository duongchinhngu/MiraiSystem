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
    public class ShoesImageService : IShoesImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShoesImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(ShoesImageDto dto)
        {
            var entity = _mapper.Map<ShoesImage>(dto);
            await _unitOfWork.ShoesImageRepository.Insert(entity);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<ShoesImageDto>> GetAll()
        {
            var entities = await _unitOfWork.ShoesImageRepository.GetAll();
            return _mapper.Map<IEnumerable<ShoesImageDto>>(entities).ToList();
        }

        public Task<ShoesImageDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ShoesImageDto> GetById(string id)
        {
            var entity = await _unitOfWork.ShoesImageRepository.GetById(id);
            return _mapper.Map<ShoesImageDto>(entity);
        }

        public async Task Remove(ShoesImageDto dto)
        {
            var entity = _mapper.Map<ShoesImage>(dto);
            await _unitOfWork.ShoesImageRepository.Delete(entity);
            await _unitOfWork.Commit();
        }

        public async Task Update(ShoesImageDto dto)
        {
            var entity = _mapper.Map<ShoesImage>(dto);
            await _unitOfWork.ShoesImageRepository.Update(entity);
            await _unitOfWork.Commit();
        }
    }
}

