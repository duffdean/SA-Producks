using ProductsReprised.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsReprised.Core.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category c);
        void Edit(Category c);
        void Delete(Category c);
        void Save(Category c);
        IEnumerable<Category> GetCategorys();
    }
}
