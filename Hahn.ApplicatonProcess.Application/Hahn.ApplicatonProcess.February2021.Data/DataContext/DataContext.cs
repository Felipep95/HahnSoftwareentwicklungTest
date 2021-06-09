using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.February2021.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
    }
}
