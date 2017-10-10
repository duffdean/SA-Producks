using BrandsReprised.Service.Interfaces;
using ProductsReprised.Core.Models;
using ProductsReprised.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandsReprised.Service
{
    public class BrandService : IBrandService
    {
        private IRepository<Brand> brandRepository;

        public BrandService(IRepository<Brand> brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public IQueryable<Brand> GetBrands()
        {
            return brandRepository.GetAll;
        }

        public Brand GetBrand(int id)
        {
            return brandRepository.GetById(id);
        }

        public void AddBrand(Brand brand)
        {
            brandRepository.Insert(brand);
        }

        public void UpdateBrand(Brand brand)
        {
            brandRepository.Update(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            brandRepository.Delete(brand);
        }
    }
}