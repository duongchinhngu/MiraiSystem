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
    public class ConcreteShoesService : IConcreteShoesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConcreteShoesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(ConcreteShoesDto dto)
        {
            var entity = _mapper.Map<ConcreteShoes>(dto);
            await _unitOfWork.InventoryShoesRepository.Insert(entity);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<ConcreteShoesDto>> GetAll()
        {
            var entities = await _unitOfWork.InventoryShoesRepository.GetAll();
            return _mapper.Map<IEnumerable<ConcreteShoesDto>>(entities).ToList();
        }

        public Task<ConcreteShoesDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ConcreteShoesDto> GetById(string id)
        {
            var entity = await _unitOfWork.InventoryShoesRepository.GetById(id);
            return _mapper.Map<ConcreteShoesDto>(entity);
        }

        public async Task Remove(ConcreteShoesDto dto)
        {
            var entity = _mapper.Map<ConcreteShoes>(dto);
            await _unitOfWork.InventoryShoesRepository.Delete(entity);
            await _unitOfWork.Commit();
        }

        public async Task Update(ConcreteShoesDto dto)
        {
            var entity = _mapper.Map<ConcreteShoes>(dto);
            await _unitOfWork.InventoryShoesRepository.Update(entity);
            await _unitOfWork.Commit();
        }
    }
}
