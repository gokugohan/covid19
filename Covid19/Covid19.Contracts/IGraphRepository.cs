using Covid19.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19.Contracts
{
    public interface IGraphRepository : IRepositoryBase<Graph>
    {
        bool Exist(Guid id);

        IEnumerable<Graph> GetGraphsByCreatedDate(DateTime dateTime);
        Task<IEnumerable<Graph>> GetGraphsByCreatedDateAsync(DateTime dateTime);

        IEnumerable<DateTime> GetDateTimes();
        

        Task<IEnumerable<DateTime>> GetDateTimesAsync();

        IEnumerable<GraphGroupByModel> GraphsGroupByCreatedAt();

    }
}
