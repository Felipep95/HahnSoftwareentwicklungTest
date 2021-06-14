using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using System;

namespace Hahn.ApplicatonProcess.February2021.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
            : base(options)
        {

        }

        public DbSet<Asset> Assets { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Asset>().HasData(new Asset(1, "Test1", Department.HQ, "Brazil", "Brazil@hotmail.com", DateTime.UtcNow, true));
        //    modelBuilder.Entity<Asset>().HasData(new Asset(2, "Test2", Department.Store1, "Germany", "Germany@hotmail.com", DateTime.UtcNow, true));
        //    modelBuilder.Entity<Asset>().HasData(new Asset(3, "Test3", Department.Store2, "France", "France@hotmail.com", DateTime.UtcNow, false));
        //    modelBuilder.Entity<Asset>().HasData(new Asset(4, "Test4", Department.Store3, "Denmark", "Denmark@hotmail.com", DateTime.UtcNow, false));
        //    modelBuilder.Entity<Asset>().HasData(new Asset(5, "Test5", Department.MaintenanceStation, "Switzerland", "Switzerland@hotmail.com", DateTime.UtcNow, false));
        //}
    }
}
