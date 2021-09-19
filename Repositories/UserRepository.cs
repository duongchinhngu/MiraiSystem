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
        public UserRepository(MiraiDBContext context) : base(context)
        {
        }
    }
}
