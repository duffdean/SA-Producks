using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepriseMyProducks.ViewModels
{
    public class Store
    {
        public virtual List<Brand> Brands { get; set; }
        public virtual List<Category> Categories { get; set; }
        public List<Product> Products{ get; set; }
    }
}