using MiraiSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Services.IServices
{
    public interface IAddressService : IBaseService<AddressDto>
    {
        Task<IEnumerable<AddressDto>> GetByUserID(string userId);
    }
}
