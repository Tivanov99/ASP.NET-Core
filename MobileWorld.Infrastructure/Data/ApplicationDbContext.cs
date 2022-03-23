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

            builder.Entity<FavoriteAd>()
                .HasOne(f => f.Ad)
                .WithMany(a => a.Fans)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<FavoriteAd>()
                .HasOne(f => f.User)
                .WithMany(x => x.FavoriteAds)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }


        public DbSet<Ad> Ads { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<FavoriteAd> FavoriteAds { get; set; }
    }
}