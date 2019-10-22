using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Mappings;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Context
{
    public class PractitionerContext : DbContext
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        protected PractitionerContext(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public DbSet<Practitioner> Practitioners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PractitionerMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Get configurations from the app settings
            var configuration = new ConfigurationBuilder().SetBasePath(_hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();

            // define the database to use
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        ///     Discard all pending changes.
        /// </summary>
        public void DiscardChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
        }

    }
}