using DoorangWorld.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.Services.Interfaces
{
    public interface IExploreWorldService
    {
        Task CreateAsync(ExploreWorld explore);
        Task SoftDeleteAsync(int Id);
        Task HardDeleteAsync(int Id);
        Task<ExploreWorld> GetAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes);
        Task<List<ExploreWorld>> GettAllAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes);

        Task UpdateAsync(ExploreWorld explore);
    }
}
