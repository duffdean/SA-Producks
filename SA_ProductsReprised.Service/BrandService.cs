using SA_ProductsReprised.Repositoty.Interfaces;
using SA_ProductsReprised.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SA_ProductsReprised.Service
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Models.SA_Brand> _brandRepository;

        public BrandService(IRepository<Models.SA_Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IEnumerable<Dto.SA_Brand> GetAll()
        {
            var brands = _brandRepository.GetAll();

            return brands.Select(Map);
        }

        public Dto.SA_Brand Get(int id)
        {
            var brand = _brandRepository.Get(id);

            return brand == null ? null : Map(brand);
        }

        private static Dto.SA_Brand Map(Models.SA_Brand brand)
        {
            return new Dto.SA_Brand
            {
                ID = brand.ID,
                Name = brand.Name,
                Active = brand.Active
            };
        }
    }
}
