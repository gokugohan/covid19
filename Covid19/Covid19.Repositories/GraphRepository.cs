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
    public class GraphRepository : RepositoryBase<Graph>, IGraphRepository
    {
        public GraphRepository(RepositoryContext context) : base(context)
        {
        }

        public bool Exist(Guid id)
        {
            return this.Context.Graphs.Any(m => m.Id.Equals(id));
        }

        public IEnumerable<DateTime> GetDateTimes()
        {
            return this.Context.Graphs.Select(m => m.CreatedAt.Date).Distinct().ToList();
        }
        public async Task<IEnumerable<DateTime>> GetDateTimesAsync()
        {
            return await this.Context.Graphs.Select(m => m.CreatedAt.Date).Distinct().ToListAsync();
        }

        public IEnumerable<Graph> GetGraphsByCreatedDate(DateTime dateTime)
        {
            return this.Context.Graphs.Where(m => m.CreatedAt.Date.Equals(dateTime.Date)).ToList();

        }
        public async Task<IEnumerable<Graph>> GetGraphsByCreatedDateAsync(DateTime dateTime)
        {
            return await this.Context.Graphs.Where(m => m.CreatedAt.Date.Equals(dateTime.Date)).ToListAsync();

        }

        public IEnumerable<GraphGroupByModel> GraphsGroupByCreatedAt()
        {
            var lista = this.Context.Graphs.Select(m => new Graph
            {
                Id = m.Id,
                Kazu = m.Kazu,
                Total = m.Total,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt
            }).OrderBy(m => m.CreatedAt).ToList();

            var group = lista.GroupBy(m => m.CreatedAt).OrderBy(m => m.Key).Select(m => new GraphGroupByModel
            {
                Group = m.Key,
                Graphs = m.OrderBy(s => s.CreatedAt).ToList()
            }).ToList();

            return group;
        }
    }
}
