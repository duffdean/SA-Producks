using Microsoft.EntityFrameworkCore;

namespace SA_ProductsReprised.Models
{
    public class ProdDbContext : DbContext
    {
        public ProdDbContext(DbContextOptions<ProdDbContext> options)
            : base(options)
        { }

        public virtual DbSet<SA_Product> SA_Product { get; set; }

        public virtual DbSet<SA_Category> SA_Category { get; set; }

        public virtual DbSet<SA_Brand> SA_Brand { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SA_Brand>();
            //     .HasMany(e => e.SA_Product),
            // .WithRequired(e => e.SA_Brand)
            //.HasForeignKey(e => e.BrandID);

            modelBuilder.Entity<SA_Category>();
                //.HasMany(e => e.SA_Product);
            //.WithRequired(e => e.SA_Category)
            //.HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<SA_Product>();
            //.HasOptional(e => e.SA_Product1)
            //.WithRequired(e => e.SA_Product2);
        }
    }
}