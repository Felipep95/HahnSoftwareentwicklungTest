using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.February2021.Domain.Models;


namespace Hahn.ApplicatonProcess.February2021.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("ToAddMyConnectionString");//TODO insert my connection string
        //} 

        public DbSet<Asset> Assets { get; set; }
    }
}
