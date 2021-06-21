using Ios_api.DBContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ios_api.DBContext
{
    public class IosDBContext : DbContext
    {
        public IosDBContext(DbContextOptions<IosDBContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Stock>()
        //        .HasKey(x => x.id);

        //    modelBuilder.Entity<Product>()
        //       .HasKey(x => x.id);
        //}
    }
}
