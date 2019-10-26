using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Sakamoto.TCC2.CSU.Patients.Domain.Models;
using Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Mappings;

namespace Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Context
{
    public class PatientContext : DbContext
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        protected PatientContext(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public DbSet<Patient> Patients { get; set; }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Get configurations from the app settings
            var configuration = new ConfigurationBuilder().SetBasePath(_hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();

            // define the database to use
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}