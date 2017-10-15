using System;
using System.Collections.Generic;
using System.Text;

namespace SA_ProductsReprised.Dto
{
    public class SA_Product
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public int BrandID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        public int StockLevel { get; set; }

        public bool Active { get; set; }        
    }
}
