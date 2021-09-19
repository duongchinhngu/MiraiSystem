using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Services.IServices
{
    public interface IBaseService<TDto>
        where TDto : class
    {
        Task Add(TDto dto);
        Task Update(TDto dto);
        Task Remove(TDto dto);
        Task<TDto> GetById(string id);
        Task<IEnumerable<TDto>> GetAll();
    }
}
