using Newtonsoft.Json;
using SA_ProductsReprised.Repositoty.Interfaces;
using SA_ProductsReprised.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

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
            var categories = _categoryRepository.GetAll();

            return categories.Select(Map);
        }

        public List<Dto.SA_Category> GetAllWithUnderCutters()
        {
            var categories = _categoryRepository.GetAll();

            //Need to make these calls to APIs more generic for all services
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://undercutters.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpResponseMessage response = client.GetAsync("api/Category").Result;
            string data = response.Content.ReadAsStringAsync().Result;

            List<Dto.SA_Category> apiCategories = JsonConvert.DeserializeObject<List<Dto.SA_Category>>(data);
            IEnumerable<Dto.SA_Category> allCategories = categories.Select(Map);

            allCategories = allCategories.ToList().Concat(apiCategories);
            return allCategories.ToList();
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
