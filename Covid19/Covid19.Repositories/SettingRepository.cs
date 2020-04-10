using Covid19.Contracts;
using Covid19.Entities;
using Covid19.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19.Repositories
{
    public class SettingRepository : RepositoryBase<Setting>, ISettingRepository
    {
        public SettingRepository(RepositoryContext context) : base(context)
        {
        }

        public bool Exist(Guid id)
        {
            return this.Context.Settings.Any(m => m.Id.Equals(id));
        }

        public IEnumerable<Setting> GetAllSettings()
        {
            return this.FindAll().OrderBy(x => x.Key);
        }

        public IDictionary<string, string> GetAllSettingsAsDictionary()
        {
            return this.FindAll().ToDictionary(x => x.Key, x => x.Value);
        }

        public Task<IDictionary<string, string>> GetAllSettingsAsDictionaryAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Setting>> GetAllSettingsAsync()
        {
            return await this.FindAll().OrderBy(m => m.Key).ToListAsync();
        }

        public IEnumerable<SettingGroupModel> GetSettingGroups()
        {
            var lista = this.Context.Settings.Select(m => new Setting
            {
                Id = m.Id,
                Name = m.Name,
                Key = m.Key,
                Value = m.Value,
                Type = m.Type,
                Group = m.Group,
                CreatedAt = m.CreatedAt
            }).OrderBy(m=>m.CreatedAt).ToList();
            
            var group = lista.GroupBy(m => m.Group).OrderBy(m => m.Key).Select(m => new SettingGroupModel
            {
                Group = m.Key,
                Settings = m.OrderBy(s => s.Key).ToList()
            }).ToList();

            return group;
        }
    }
}
