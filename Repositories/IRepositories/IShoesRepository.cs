using MiraiSystem.Helpers.FilterHelpers;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Repositories.IRepositories
{
    public interface IShoesRepository : IGenericRepository<Shoes>
    {
        PagedList<Shoes> Filter(ShoesFilter filter);
    }
}
