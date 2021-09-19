using MiraiSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Services.IServices
{
    public interface IProductImageService : IBaseService<ProductImageDto>
    {
        Task<IEnumerable<ProductImageDto>> GetBySku(string sku);
    }
}
