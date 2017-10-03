using ProductsReprised.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProductsReprised.Core.Interfaces;
using ProductsReprised.Core;

namespace ProductsReprised.Core.Interfaces
{
    class CategoryRepository : ICategoryRepository, IDisposable
    {
        private DataContext context;

        public CategoryRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetCategorys()
        {
            return context.SA_Category.ToList();
        }

        public void Add(Category category)
        {
            context.SA_Category.Add(category);
        }

        public void Edit(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
        }

        public void Save(Category category)
        {
            context.SaveChanges();
        }

        public void Delete(Category category)
        {
            //Not this... Will need to soft delete, so update active flag to false.
            context.SA_Category.Remove(category);
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