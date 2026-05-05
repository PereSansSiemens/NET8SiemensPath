using Microsoft.EntityFrameworkCore;
using Shared.Models.Entities;

namespace VaquerSansPere.Backend.WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TriangleEntity> Triangles { get; set; }
        public DbSet<ListToOrderEntity> ListToOrders { get; set; }
        public DbSet<CircleEntity> Circles { get; set; }
        public DbSet<GreatestNumListEntity> GreatestNumLists { get; set; }
        public DbSet<LowestNumListEntity> LowestNumLists { get; set; }
        public DbSet<PalindromeEntity> Palindromes { get; set; }
        public DbSet<PrimeEntity> Primes { get; set; }
        public DbSet<BookEntity> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PVS-BBDD");
            base.OnModelCreating(modelBuilder);
        }
    }
}
