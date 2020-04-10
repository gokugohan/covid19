using Covid19.Contracts;
using Covid19.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        protected readonly RepositoryContext context;
        private IGraphRepository graphRepository;
        private IQuarantineRepository quarantineRepository;
        private ISettingRepository settingRepository;

        public RepositoryWrapper(RepositoryContext context)
        {
            this.context = context;
        }
        
        public IQuarantineRepository Quarantine
        {
            get
            {
                if (this.quarantineRepository == null)
                {
                    this.quarantineRepository = new QuarantineRepository(this.context);
                }
                return this.quarantineRepository;
            }
        }

     
        public ISettingRepository Setting {
            get
            {
                if (this.settingRepository == null)
                {
                    this.settingRepository = new SettingRepository(this.context);
                }
                return this.settingRepository;
            }
        }

        public IGraphRepository Graph
        {
            get
            {
                if(this.graphRepository == null)
                {
                    this.graphRepository = new GraphRepository(this.context);
                }
                return this.graphRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
