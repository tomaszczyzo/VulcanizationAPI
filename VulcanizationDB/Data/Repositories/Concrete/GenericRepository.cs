using Microsoft.EntityFrameworkCore;
using VulcanizationAPI.Infrastructure.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyWebApi.Infrastructure.Data.Repositories
{
    public class GenericRepository<TEntity> 
        : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet
                .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbSet
                .FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet
                .Where(predicate)
                .ToListAsync();
        }
        public async Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet
                .AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet
                .AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet
                .Attach(entity);
            _context
                .Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet
                    .Attach(entity);
            }
            _dbSet
                .Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet
                .RemoveRange(entities);
        }
    }
}