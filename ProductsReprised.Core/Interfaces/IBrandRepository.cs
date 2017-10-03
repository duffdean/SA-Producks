using ProductsReprised.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsReprised.Core.Interfaces
{
    public interface IBrandRepository
    {
        void Add(Brand p);
        void Edit(Brand p);
        void Delete(Brand p);
        void Save(Brand p);
        IEnumerable<Brand> GetBrands();
    }
}
