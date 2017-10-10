using ProductsReprised.Core.Models;
using ProductsReprised.Data.Interfaces;
using ProductsReprised.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsReprised.Service
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IQueryable<Category> GetCategorys()
        {
            return categoryRepository.GetAll;
        }

        public Category GetCategory(int id)
        {
            return categoryRepository.GetById(id);
        }

        public void AddCategory(Category category)
        {
            categoryRepository.Insert(category);
        }

        public void UpdateCategory(Category category)
        {
            categoryRepository.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            categoryRepository.Delete(category);
        }
    }
}