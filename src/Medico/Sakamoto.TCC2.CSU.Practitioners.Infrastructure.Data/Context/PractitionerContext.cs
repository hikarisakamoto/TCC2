﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Models;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Mappings;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Context
{
    public class PractitionerContext : DbContext
    {
        public DbSet<Practitioner> Practitioners { get; set; }

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
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PractitionerMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}