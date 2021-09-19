using MiraiSystem.Dtos;
using MiraiSystem.Helpers.FilterHelpers;
using MiraiSystem.Helpers.PagingHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Services.IServices
{
    public interface IShoesService : IBaseService<ShoesDto>
    {
        Response<ShoesDto> Filter(ShoesFilter filter);
        Task<IEnumerable<ShoesDto>> GetByModelCode(string modelCode);
    }
}
