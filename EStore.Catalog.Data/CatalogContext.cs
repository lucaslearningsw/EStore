using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStore.Catalog.Domain;
using EStore.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace EStore.Catalog.Data
{
    public class CatalogContext : DbContext, IUnitOfWork
    {
        public CatalogContext(DbContextOptions<CatalogContext> options)
        :base(options){}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetMaxLength(100);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.GetType().GetProperty("DateTimeCreation") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateTimeCreation").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateTimeCreation").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
        
    }
}
