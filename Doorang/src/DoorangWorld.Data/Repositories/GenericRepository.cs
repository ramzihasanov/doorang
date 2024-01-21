using DoorangWorld.Core.Entities;
using DoorangWorld.Core.Repositories;
using DoorangWorld.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DoorangWorld.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            this._context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(T entity)
        {
           await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public Task<List<T>>GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
        {
           var query=Table.AsQueryable();
            if(expression != null) query = query.Where(expression);
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query=query.Include(include);
                }
            }
            return query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
        {
            var query = Table.AsQueryable();
            if (expression != null) query = query.Where(expression);
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
