using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepriseMyProducks.ViewModels
{
    public class Product
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Price { get; set; }
        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
    }
}