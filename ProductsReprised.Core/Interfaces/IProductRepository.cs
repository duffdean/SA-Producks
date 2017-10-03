using ProductsReprised.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsReprised.Core.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product p);
        void Edit(Product p);
        void Delete(Product p);
        void Save(Product p);
        IEnumerable<Product> GetProducts();
        Product GetProductById(int Id);                 
    }
}
