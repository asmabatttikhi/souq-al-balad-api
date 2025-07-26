using Microsoft.EntityFrameworkCore;
using AdsApiSQLite.Models;

namespace AdsApiSQLite.Data
{
    public class AdsDbContext : DbContext
    {
        public AdsDbContext(DbContextOptions<AdsDbContext> options) : base(options) { }

        public DbSet<Ad> Ads => Set<Ad>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=ads.db");
    }
}