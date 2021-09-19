using Microsoft.EntityFrameworkCore;
using MiraiSystem.Helpers.FilterHelpers;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Helpers.SortHelpers;
using MiraiSystem.Models;
using MiraiSystem.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Repositories
{
    public partial class ShoesRepository : GenericRepository<Shoes>, IShoesRepository
    {
        private readonly MiraiDBContext _context;
        public ShoesRepository(MiraiDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shoes>> GetByModelCode(string modelCode)
        {
            return await _context.Shoes
                .Where(s => s.ModelCode.Equals(modelCode))
                .OrderBy(s => s.Gender)
                .Select(s => s.GetShoes(s.ProductImages))
                .ToListAsync();
        }

    }
}
