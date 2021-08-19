using MiraiSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ShoesRepository ShoesRepository { get; }
        ShoesImageRepository ShoesImageRepository { get; }
        ConcreteShoesRepository InventoryShoesRepository { get; }
        UserRepository UserRepository { get; }
        Task Commit();
        Task Rollback();
    }
}
