using Microsoft.EntityFrameworkCore;
using MiraiSystem.Helpers.FilterHelpers.UserFilters;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Models;
using MiraiSystem.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly MiraiDBContext context;
        public UserRepository(MiraiDBContext context) : base(context)
        {
            this.context = context;
        }

        public PagedList<User> Filter(UserFilter filter)
        {
            var entities = context.Users.AsQueryable();
            filter.ApplySearch(ref entities);
            filter.ApplyFilter(ref entities);
            filter.ApplySort(ref entities);
            return filter.ApplyPaging(entities);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await context.Users.Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();
        }
    }
}
