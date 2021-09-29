using MiraiSystem.Models;
using MiraiSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiraiDBContext _context;
        private bool disposedValue;
        
        public ShoesRepository ShoesRepository { get; private set; }
        public ProductImageRepository ProductImageRepository { get; private set; }
        public UserRepository UserRepository { get; private set; }
        public OrderRepository OrderRepository { get; private set; }
        public OrderItemRepository OrderItemRepository { get; private set; }
        public TransactionRepository TransactionRepository { get; private set; }
        public AddressRepository AddressRepository { get; private set; }

        public UnitOfWork(MiraiDBContext context)
        {
            _context = context;
            InitRepositories();
        }
        private void InitRepositories()
        {
            ShoesRepository = new ShoesRepository(_context);
            ProductImageRepository = new ProductImageRepository(_context);
            UserRepository = new UserRepository(_context);
            OrderRepository = new OrderRepository(_context);
            OrderItemRepository = new OrderItemRepository(_context);
            TransactionRepository = new TransactionRepository(_context);
            AddressRepository = new AddressRepository(_context);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Rollback()
        {
            await _context.DisposeAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
