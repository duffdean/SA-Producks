using ProductsReprised.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProductsReprised.Core.Interfaces
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private DataContext context;

        public ProductRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.SA_Product.ToList();
        }

        public Product GetProductById(int id)
        {
            return context.SA_Product.Find(id);
        }

        public void Add(Product product)
        {
            context.SA_Product.Add(product);
        }

        public void Edit(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
        }

        public void Save(Product product)
        {
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            //Not this... Will need to soft delete, so update active flag to false.
            context.SA_Product.Remove(product);
        }
        
        //Below is for IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
