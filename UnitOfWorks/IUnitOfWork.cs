using MiraiSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        ShoesRepository ShoesRepository { get; }
        ProductImageRepository ProductImageRepository { get; }
        OrderRepository OrderRepository { get; }
        OrderItemRepository OrderItemRepository { get; }
        UserRepository UserRepository { get; }
        TransactionRepository TransactionRepository { get; }
        AddressRepository AddressRepository { get; }
        Task Commit();
        Task Rollback();
    }
}
