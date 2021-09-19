using Microsoft.EntityFrameworkCore;
using MiraiSystem.Helpers.FilterHelpers;
using MiraiSystem.Models;
using MiraiSystem.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MiraiDBContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(MiraiDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
