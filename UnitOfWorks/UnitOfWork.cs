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
        //
        public ShoesRepository ShoesRepository { get; private set; }
        public ConcreteShoesRepository InventoryShoesRepository { get; private set; }
        public ShoesImageRepository ShoesImageRepository { get; private set; }
        public UserRepository UserRepository { get; private set; }
        public UnitOfWork(MiraiDBContext context)
        {
            _context = context;
            InitRepositories();
        }
        private void InitRepositories()
        {
            ShoesRepository = new ShoesRepository(_context);
            InventoryShoesRepository = new ConcreteShoesRepository(_context);
            ShoesImageRepository = new ShoesImageRepository(_context);
            UserRepository = new UserRepository(_context);
        }



        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Rollback()
        {
            await _context.DisposeAsync();
        }
    }
}
