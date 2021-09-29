using Microsoft.EntityFrameworkCore;
using MiraiSystem.Helpers.FilterHelpers;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Models;
using MiraiSystem.Repositories.IRepositories;
using System;
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
    }
}
