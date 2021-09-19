using Microsoft.EntityFrameworkCore;
using MiraiSystem.Models;
using MiraiSystem.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Repositories
{
    public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
    {
        private readonly MiraiDBContext _context;
        public ProductImageRepository(MiraiDBContext context) : base(context)
        {
            _context = context;
        }
         public async Task<IEnumerable<ProductImage>> GetBySku(string sku)
        {
            return await _context.ProductImage.Where(i => i.Sku.Equals(sku)).ToListAsync();
        }

    }
}
