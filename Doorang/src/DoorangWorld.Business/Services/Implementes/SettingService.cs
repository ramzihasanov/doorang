using DoorangWorld.Business.CustomException.SettingException;
using DoorangWorld.Business.Services.Interfaces;
using DoorangWorld.Core.Entities;
using DoorangWorld.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.Services.Implementes
{
    public class SettingService : IsettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            this._settingRepository = settingRepository;
        }
        public async Task<Setting> GetSettingAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes)
        {
         return  await _settingRepository.GetByIdAsync(expression, includes);
        }

        public async Task<List<Setting>> GettAllsetting(Expression<Func<Setting, bool>>? expression = null, params string[]? includes)
        {
            return await _settingRepository.GetAllAsync(expression, includes);
        }

        public async Task Update(Setting setting)
        {
           var set=await _settingRepository.GetByIdAsync(x=>x.Key==setting.Key);
            if (set==null)
            {
                throw new NullSettingException();
            }
            set.Value = setting.Value;

           await _settingRepository.CommitAsync();
            
        }
    }
}
