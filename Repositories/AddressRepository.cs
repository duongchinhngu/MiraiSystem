using Microsoft.EntityFrameworkCore;
using MiraiSystem.Models;
using MiraiSystem.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly MiraiDBContext context;
        public AddressRepository(MiraiDBContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Address>> GetByUserID(string userId)
        {
            return await context.Addresses.Where(a => a.UserId.Equals(userId)).ToListAsync();
        }
    }
}
