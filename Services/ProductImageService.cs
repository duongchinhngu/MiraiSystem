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
    public class ProductImageService : IProductImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(ProductImageDto dto)
        {
            var entity = _mapper.Map<ProductImage>(dto);
            await _unitOfWork.ProductImageRepository.Insert(entity);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<ProductImageDto>> GetAll()
        {
            var entities = await _unitOfWork.ProductImageRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductImageDto>>(entities).ToList();
        }

        public async Task<ProductImageDto> GetById(string id)
        {
            var entity = await _unitOfWork.ProductImageRepository.GetById(id);
            return _mapper.Map<ProductImageDto>(entity);
        }


        public async Task<IEnumerable<ProductImageDto>> GetBySku(string sku)
        {
            var entities = await _unitOfWork.ProductImageRepository.GetBySku(sku);
            return _mapper.Map<IEnumerable<ProductImageDto>>(entities);
        }

        public async Task Remove(ProductImageDto dto)
        {
            var entity = _mapper.Map<ProductImage>(dto);
            await _unitOfWork.ProductImageRepository.Delete(entity);
            await _unitOfWork.Commit();
        }

        public async Task Update(ProductImageDto dto)
        {
            var entity = _mapper.Map<ProductImage>(dto);
            await _unitOfWork.ProductImageRepository.Update(entity);
            await _unitOfWork.Commit();
        }
    }
}

