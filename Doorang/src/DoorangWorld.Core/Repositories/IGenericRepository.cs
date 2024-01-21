using DoorangWorld.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        DbSet<T> Table {  get; }
        Task<int> CommitAsync();
        Task CreateAsync(T entity);
        void Delete(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>>?expression=null,params string[]? includes);
        Task<T> GetByIdAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes);
    }
}
