using Microsoft.EntityFrameworkCore;
using MyBot.Data.Context;
using MyBot.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBot.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>  where TEntity : class
    {
        #region injections
        protected BotContext _context;
        private DbSet<TEntity> _dbSet;

        public BaseRepository(BotContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        #endregion


        public async Task InsertAsync(TEntity entity) => await _dbSet.AddAsync(entity);
        public void Update(TEntity entity) => _dbSet.Update(entity);
        public void Delete(TEntity entity) => _dbSet.Remove(entity);
        public async Task<TEntity> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task DeleteByIdAsync(int id)
        {
            var model = await _dbSet.FindAsync(id);
            Delete(model);
        }
        public async Task SaveChanges() => await _context.SaveChangesAsync();

    }
}
