using MiraiSystem.Dtos;
using MiraiSystem.Helpers.FilterHelpers.UserFilters;
using MiraiSystem.Helpers.PagingHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Services.IServices
{
    public interface IUserService : IBaseService<UserDto>
    {
        Response<UserDto> Filter(UserFilter filter);
        Task<UserDto> GetByEmail(string email);
    }
}
