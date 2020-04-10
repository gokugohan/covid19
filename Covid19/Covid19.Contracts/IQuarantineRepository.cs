using Covid19.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19.Contracts
{
    public interface IQuarantineRepository : IRepositoryBase<Quarantine>
    {
        bool Exist(Guid id);
        IEnumerable<Quarantine> GetQuarantinesByCreatedDate(DateTime dateTime);
        Task<IEnumerable<Quarantine>> GetQuarantinesByCreatedDateAsync(DateTime dateTime);

        IEnumerable<DateTime> GetDateTimes();
        Task<IEnumerable<DateTime>> GetDateTimesAsync();
        IEnumerable<QuarantineGroupByDateModel> QuarantinesGroupByCreatedAt();
        //IEnumerable<QuarantineGroupByDateModel> QuarantinesGroupByCreatedAt(DateTime date);

        Quarantine GetQuarantinByMunicipio(string municipio, DateTime today);
        Task<Quarantine> GetQuarantinByMunicipioAsync(string municipio, DateTime today);
        IEnumerable<QuarantineGroupMunicipioteModel> QuarantinesGroupByMunicipio();

        //IEnumerable<QuarantineGroupMunicipioteModel> QuarantinesGroupByMunicipio(DateTime dateTime);


        
        //IEnumerable<QuarantineGroupByDateModel> QuarantinesGroupBy(int group);

    }
}
