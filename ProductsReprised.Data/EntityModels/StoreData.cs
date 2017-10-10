namespace ProductsReprised.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoreData : DbContext
    {
        public StoreData()
            : base("name=StoreData")
        {
        }

        public virtual DbSet<SA_Brand> SA_Brand { get; set; }
        public virtual DbSet<SA_Category> SA_Category { get; set; }
        public virtual DbSet<SA_Product> SA_Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SA_Brand>()
                .HasMany(e => e.SA_Product)
                .WithRequired(e => e.SA_Brand)
                .HasForeignKey(e => e.BrandID);

            modelBuilder.Entity<SA_Category>()
                .HasMany(e => e.SA_Product)
                .WithRequired(e => e.SA_Category)
                .HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<SA_Product>()
                .HasOptional(e => e.SA_Product1)
                .WithRequired(e => e.SA_Product2);
        }
    }
}
