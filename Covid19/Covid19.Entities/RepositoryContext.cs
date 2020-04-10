using Covid19.Entities.Configuration;
using Covid19.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Covid19.Entities
{
    public class RepositoryContext : DbContext
    {
        
        public RepositoryContext(DbContextOptions<RepositoryContext> options):base(options)
        {
        }

        public DbSet<Quarantine> Quarantines { get; set; }
        public DbSet<Graph> Graphs { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new GraphConfiguration());
            modelBuilder.ApplyConfiguration(new QuarantineConfiguration());
            modelBuilder.ApplyConfiguration(new SettingConfiguration());

            base.OnModelCreating(modelBuilder);
        }



        /**
    * https://medium.com/oppr/net-core-using-entity-framework-core-in-a-separate-project-e8636f9dc9e5
    */
        private class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
        {
            /*
         * covid19_connection_string
         * covid19
         */
            private const string CONNECTION_STRING_NAME = "covid19_connection_string";

            public RepositoryContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Covid19.Web/appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<RepositoryContext>();
                var connectionString = configuration.GetConnectionString(CONNECTION_STRING_NAME);
                builder.UseSqlServer(connectionString);
                return new RepositoryContext(builder.Options);
            }
        }
    }
}
