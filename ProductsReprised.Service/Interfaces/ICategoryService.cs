using ProductsReprised.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsReprised.Service.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<Category> GetCategorys();
        Category GetCategory(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
