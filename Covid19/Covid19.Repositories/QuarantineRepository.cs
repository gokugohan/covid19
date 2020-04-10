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
    public class QuarantineRepository : RepositoryBase<Quarantine>, IQuarantineRepository
    {
        public QuarantineRepository(RepositoryContext context) : base(context)
        {
        }

        public bool Exist(Guid id)
        {
            return this.Context.Quarantines.Any(m => m.Equals(id));
        }

        public IEnumerable<DateTime> GetDateTimes()
        {
            return this.Context.Quarantines.Select(m => m.CreatedAt.Date).Distinct().ToList();
        }


        public async Task<IEnumerable<DateTime>> GetDateTimesAsync()
        {
            return await this.Context.Quarantines.Select(m => m.CreatedAt.Date).Distinct().ToListAsync();
        }

        

        public IEnumerable<Quarantine> GetQuarantinesByCreatedDate(DateTime dateTime)
        {
            return this.Context.Quarantines.Where(m => m.CreatedAt.Date.Equals(dateTime.Date)).ToList();
        }


        public async Task<IEnumerable<Quarantine>> GetQuarantinesByCreatedDateAsync(DateTime dateTime)
        {
            return await this.Context.Quarantines.Where(m => m.CreatedAt.Date.Equals(dateTime.Date)).ToListAsync();
        }




        public IEnumerable<QuarantineGroupByDateModel> QuarantinesGroupByCreatedAt()
        {
            var lista = this.Context.Quarantines.Select(m => new Quarantine
            {
                Id = m.Id,
               Munisipio = m.Munisipio,
               KuarentenaObrigatorio = m.KuarentenaObrigatorio,
               AutoKuarentena = m.AutoKuarentena,
               PassaQuarentena = m.PassaQuarentena,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt
            }).OrderBy(m => m.CreatedAt).ToList();

            var group = lista.GroupBy(m => m.CreatedAt).OrderBy(m => m.Key).Select(m => new QuarantineGroupByDateModel
            {
                Group = m.Key,
                Quarantines = m.OrderBy(s => s.CreatedAt).ToList()
            }).ToList();

            return group;
        }


        public Quarantine GetQuarantinByMunicipio(string municipio, DateTime today)
        {
            var result = this.Context.Quarantines.Where(m => m.CreatedAt.Date.Equals(today.Date)).Where(m => m.Munisipio.ToLower().Equals(municipio.ToLower())).SingleOrDefault();
            return result ?? null;
        }

        public async Task<Quarantine> GetQuarantinByMunicipioAsync(string municipio, DateTime today)
        {
            var result = await this.Context.Quarantines.Where(m => m.CreatedAt.Date.Equals(today.Date))
                .Where(m => m.Munisipio.ToLower().Equals(municipio.ToLower())).SingleOrDefaultAsync();
            
            return result ?? null;
        }

        public IEnumerable<QuarantineGroupMunicipioteModel> QuarantinesGroupByMunicipio()
        {
            var lista = this.Context.Quarantines.Select(m => new Quarantine
            {
                Id = m.Id,
                Munisipio = m.Munisipio,
                KuarentenaObrigatorio = m.KuarentenaObrigatorio,
                AutoKuarentena = m.AutoKuarentena,
                PassaQuarentena = m.PassaQuarentena,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt
            }).OrderBy(m => m.CreatedAt).ToList();

            var group = lista.GroupBy(m => m.Munisipio).OrderBy(m => m.Key).Select(m => new QuarantineGroupMunicipioteModel
            {
                Group = m.Key,
                Quarantines = m.OrderBy(s => s.CreatedAt).ToList()
            }).ToList();

            return group;
        }



    }
}
