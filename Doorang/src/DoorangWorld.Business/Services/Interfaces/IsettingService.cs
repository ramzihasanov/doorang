using DoorangWorld.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.Services.Interfaces
{
    public interface IsettingService
    {
        Task<Setting> GetSettingAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes);
        Task<List<Setting>> GettAllsetting(Expression<Func<Setting, bool>>? expression = null, params string[]? includes);
        Task Update(Setting setting);
    }
}
