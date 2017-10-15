using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA_ProductsReprised.Web.ViewModels
{
    public class Product
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Price { get; set; }
        public virtual bool OutOfStock { get; set; }
        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
