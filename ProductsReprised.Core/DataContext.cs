namespace ProductsReprised.Core
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ProductsReprised.Models;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Brand> SA_Brand { get; set; }
        public virtual DbSet<Category> SA_Category { get; set; }
        public virtual DbSet<Product> SA_Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Brand>()
            //    .HasMany(e => e.Product)
            //    .WithRequired(e => e.Brand)
            //    .HasForeignKey(e => e.BrandID);

            //modelBuilder.Entity<Category>()
            //    .HasMany(e => e.Product)
            //    .WithRequired(e => e.Category)
            //    .HasForeignKey(e => e.CategoryID);

            //modelBuilder.Entity<Product>()
            //    .HasOptional(e => e.Product1)
            //    .WithRequired(e => e.Product2);
        }
    }
}
