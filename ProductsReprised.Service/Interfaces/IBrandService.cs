using ProductsReprised.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandsReprised.Service.Interfaces
{
    public interface IBrandService
    {
        IQueryable<Brand> GetBrands();
        Brand GetBrand(int id);
        void AddBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(Brand brand);
    }
}
