using MiraiSystem.Models;
using MiraiSystem.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Repositories
{
    public class ConcreteShoesRepository : GenericRepository<ConcreteShoes>, IConcreteShoesRepository
    {
        private readonly MiraiDBContext _context;
        public ConcreteShoesRepository(MiraiDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
