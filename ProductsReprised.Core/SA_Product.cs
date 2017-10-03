namespace ProductsReprised.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SA-Product")]
    public partial class SA_Product
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public int BrandID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public double Price { get; set; }

        public int StockLevel { get; set; }

        public bool Active { get; set; }

        public virtual SA_Brand SA_Brand { get; set; }

        public virtual SA_Category SA_Category { get; set; }

        public virtual SA_Product SA_Product1 { get; set; }

        public virtual SA_Product SA_Product2 { get; set; }
    }
}
