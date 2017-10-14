using SA_ProductsReprised.Repositoty.Interfaces;
using SA_ProductsReprised.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SA_ProductsReprised.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Models.SA_Category> _categoryRepository;

        public CategoryService(IRepository<Models.SA_Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Dto.SA_Category> GetAll()
        {
            var categorys = _categoryRepository.GetAll();

            return categorys.Select(Map);
        }

        public Dto.SA_Category Get(int id)
        {
            var category = _categoryRepository.Get(id);

            return category == null ? null : Map(category);
        }

        private static Dto.SA_Category Map(Models.SA_Category category)
        {
            return new Dto.SA_Category
            {
                ID = category.ID,
                Name = category.Name,
                Description = category.Description,
                Active = category.Active
            };
        }
    }
}
