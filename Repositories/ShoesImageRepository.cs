using MiraiSystem.Models;
using MiraiSystem.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Repositories
{
    public class ShoesImageRepository : GenericRepository<ShoesImage>, IShoesImageRepository
    {
        private readonly MiraiDBContext _context;
        public ShoesImageRepository(MiraiDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
