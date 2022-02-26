using AppData.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AppData.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GlobalConstants.sqlConnection);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
