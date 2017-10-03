using ProductsReprised.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProductsReprised.Core.Interfaces;
using ProductsReprised.Core;

namespace BrandsReprised.Core.Interfaces
{
    public class BrandRepository : IBrandRepository, IDisposable
    {
        private DataContext context;

        public BrandRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Brand> GetBrands()
        {
            return context.SA_Brand.ToList();
        }

        public void Add(Brand brand)
        {
            context.SA_Brand.Add(brand);
        }

        public void Edit(Brand brand)
        {
            context.Entry(brand).State = EntityState.Modified;
        }

        public void Save(Brand brand)
        {
            context.SaveChanges();
        }

        public void Delete(Brand brand)
        {
            //Not this... Will need to soft delete, so update active flag to false.
            context.SA_Brand.Remove(brand);
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
