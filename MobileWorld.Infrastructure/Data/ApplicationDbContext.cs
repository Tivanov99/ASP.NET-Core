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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FavoriteAd>()
                .HasKey(f => new { f.AdId, f.UserId });

            builder.Entity<ApplicationUser>()
          .HasMany(t => t.Ads)
          .WithOne(c => c.Owner)
          .HasForeignKey(c => c.OwnerId)
          .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Ad>()
                .HasOne(a => a.Owner)
                .WithMany(o => o.Ads)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Ad>()
                .HasOne(a => a.Car)
                .WithOne(c => c.Ad)
                .HasForeignKey<Car>(c => c.AdId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Car>()
                .HasOne(c => c.Engine)
                .WithOne(e => e.Car)
                .HasForeignKey<Engine>(e => e.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Car>()
                .HasOne(c => c.Feature)
                .WithOne(f => f.Car)
                .HasForeignKey<Feature>(f => f.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Feature>()
                .HasOne(f => f.SafetyDetails)
                .WithOne(sf => sf.Feature)
                .HasForeignKey<SafetyDetail>(sf => sf.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Feature>()
                .HasOne(f => f.OthersDetails)
                .WithOne(o => o.Feature)
                .HasForeignKey<OthersDetail>(o => o.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Feature>()
                .HasOne(f => f.ComfortDetails)
                .WithOne(cd => cd.Feature)
                .HasForeignKey<ComfortDetail>(cd => cd.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Feature>()
                .HasOne(f => f.ExteriorDetails)
                .WithOne(ed => ed.Feature)
                .HasForeignKey<ExteriorDetail>(ed => ed.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Feature>()
                .HasOne(f => f.InteriorDetails)
                .WithOne(id => id.Feature)
                .HasForeignKey<InteriorDetail>(id => id.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Feature>()
                .HasOne(f => f.ProtectionDetails)
                .WithOne(pd => pd.Feature)
                .HasForeignKey<ProtectionDetail>(pd => pd.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(builder);
        }

        
    }
}