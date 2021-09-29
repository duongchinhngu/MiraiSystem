using MiraiSystem.Helpers.FilterHelpers.UserFilters;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Repositories.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        PagedList<User> Filter(UserFilter filter);
        Task<User> GetByEmail(string email);
    }
}
