using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepriseMyProducks.ViewModels
{
    public class Category
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Active { get; set; }
    }
}