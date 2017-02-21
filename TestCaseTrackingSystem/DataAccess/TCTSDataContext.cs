﻿using System.Data.Entity;
using DataAccess.Entities;
using DataAccess.Initializers;

namespace DataAccess
{
    public class TCTSDataContext : DbContext
    {
        static TCTSDataContext()
        {
            Database.SetInitializer(TCTSDataContextInitializer.Instance);
        }

        public TCTSDataContext() : base("TestCaseTrackingSystem")
        { }

        public DbSet<BacklogItem> BacklogItems { get; set; }
        public DbSet<BacklogItemType> BacklogItemTypes { get; set; }
        public DbSet<Iteration> Iterations { get; set; }
        public DbSet<TestCase> TestCases { get; set; }
        public DbSet<TestCaseStatus> TestCaseStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            TCTSDataContextInitializer.Instance.InitializeModels(modelBuilder);

            // Need to specify reletionships here because EF cannot do this automatically because of property naming
            modelBuilder.Entity<User>()
                .HasMany(t => t.BacklogItems)
                .WithOptional(t => t.AssignedTo);

            base.OnModelCreating(modelBuilder);
        }
    }
}