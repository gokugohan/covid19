using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19.Contracts
{
    public interface IRepositoryWrapper
    {
        void Save();
        Task SaveAsync();

        IQuarantineRepository Quarantine { get; }
        IGraphRepository Graph { get; }

        ISettingRepository Setting { get; }




    }
}
