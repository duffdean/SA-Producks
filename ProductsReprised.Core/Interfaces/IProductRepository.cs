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

        //void Add<TEntity>(TEntity entity);
        //void Edit<TEntity>(TEntity entity);
        //void Delete<TEntity>(TEntity entity);
        //void Save<TEntity>(TEntity entity);
    }
}
