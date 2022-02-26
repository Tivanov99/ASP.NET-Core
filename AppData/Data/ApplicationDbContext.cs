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
            optionsBuilder.UseSqlServer("Server=.;Database=MobileWorld;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
