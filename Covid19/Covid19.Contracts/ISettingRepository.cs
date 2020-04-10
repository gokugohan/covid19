using Covid19.Entities;
using Covid19.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19.Contracts
{
    public interface ISettingRepository:IRepositoryBase<Setting>
    {
        IDictionary<string, string> GetAllSettingsAsDictionary();
        Task<IDictionary<string, string>> GetAllSettingsAsDictionaryAsync();
        IEnumerable<Setting> GetAllSettings();
        Task<IEnumerable<Setting>> GetAllSettingsAsync();
        IEnumerable<SettingGroupModel> GetSettingGroups();

        bool Exist(Guid id);
    }
}
