﻿using Microsoft.EntityFrameworkCore;
using ManageBidding.Core.Data.Interfaces;
using ManageBidding.Domain.Models;

namespace ManageBidding.Data.EntityFramework.Context
{
    public class ManageBiddingContext : DbContext, IUnitOfWork
    {
        public ManageBiddingContext(DbContextOptions<ManageBiddingContext> option) : base(option)
        {

        }

        public DbSet<Bidding>? Biddings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManageBiddingContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegistrationDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("RegistrationDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("RegistrationDate").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}