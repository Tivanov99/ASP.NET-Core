using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobileWorld.Infrastructure.Data.Identity;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FavoriteAd>()
                .HasKey(f => new { f.AdId, f.UserId });

            builder.Entity<Ad>()
                .HasOne(a => a.Car)
                .WithOne(c => c.Ad)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Ad>()
                .HasOne(a => a.Owner)
                .WithMany(o => o.Ads)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Feature>()
                .HasOne(f => f.SafetyDetails)
                .WithOne(sf => sf.Feature)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Feature>()
    .HasOne(f => f.ComfortDetails)
    .WithOne(sf => sf.Feature)
    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Feature>()
    .HasOne(f => f.ExteriorDetails)
    .WithOne(sf => sf.Feature)
    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Feature>()
    .HasOne(f => f.InteriorDetails)
    .WithOne(sf => sf.Feature)
    .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Feature>()
    .HasOne(f => f.OthersDetails)
    .WithOne(sf => sf.Feature)
    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Feature>()
    .HasOne(f => f.ProtectionDetails)
    .WithOne(sf => sf.Feature)
    .OnDelete(DeleteBehavior.Cascade);



            //builder.Entity<Car>()
            //    .HasOne(c => c.Feature)
            //    .WithOne(f => f.Car)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Car>()
            //    .HasOne(e => e.Engine)
            //    .WithOne(c => c.Car)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Feature>()
            //    .HasOne(f => f.Car)
            //    .WithOne(c => c.Feature)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Engine>()
            //    .HasOne(e => e.Car)
            //    .WithOne(c => c.Engine)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Car>()
            //    .HasOne(c => c.Engine)
            //    .WithOne(f => f.ca)
            //    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }


        public DbSet<Ad> Ads { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<FavoriteAd> FavoriteAds { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<ComfortDetail> ComfortDetails { get; set; }

        public DbSet<ExteriorDetail> ExteriorDetails { get; set; }

        public DbSet<InteriorDetail> InteriorDetails { get; set; }

        public DbSet<OthersDetail> OthersDetails { get; set; }

        public DbSet<ProtectionDetail> ProtectionDetails { get; set; }

        public DbSet<SafetyDetail> SafetyDetails { get; set; }
    }
}