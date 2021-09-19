using MiraiSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Repositories.IRepositories
{
    public interface IProductImageRepository : IGenericRepository<ProductImage>
    {
        Task<IEnumerable<ProductImage>> GetBySku(string sku);
    }
}
