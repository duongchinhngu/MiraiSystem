using MiraiSystem.Dtos;
using MiraiSystem.Dtos.ExtendedDtos;
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
        Task<Response<ExtendedConcreteShoesDto>> Filter(ShoesFilter filter);
    }
}
