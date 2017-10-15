using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA_ProductsReprised.Web.ViewModels
{
    public class Store
    {
        public virtual List<Brand> Brands { get; set; }
        public virtual List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
