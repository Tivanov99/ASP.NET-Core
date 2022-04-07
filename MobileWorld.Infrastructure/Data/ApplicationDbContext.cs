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

            //builder.Entity<FavoriteAd>()
            //    .HasOne(f => f.Ad)
            //    .WithMany(a => a.Fans)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<FavoriteAd>()
            //    .HasOne(f => f.User)
            //    .WithMany(x => x.FavoriteAds)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<Car>()
            //    .HasOne(c=>c.Feature)
            //    .WithOne(f=>f.Car)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Ad>()
            //    .HasMany(c => c.Images)
            //    .WithOne(i=>i.Ad)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Ad>()
            //    .HasOne(a => a.Car)
            //    .WithOne(a => a.Ad)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Car>()
            //    .HasOne(c => c.Ad)
            //    .WithOne(a => a.Car)
            //    .OnDelete(DeleteBehavior.Cascade);


            //builder.Entity<Feature>()
            //    .HasOne(f => f.Car)
            //    .WithOne(c => c.Feature)
            //    .OnDelete(DeleteBehavior.NoAction);


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