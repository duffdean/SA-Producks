using ProductsReprised.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsReprised.DTO
{
    public class Product
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public int BrandID { get; set; }
        
        public string Name { get; set; }

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