using Microsoft.EntityFrameworkCore;
using SA_ProductsReprised.Models;
using SA_ProductsReprised.Repositoty.Interfaces;
using System;
using System.Linq;

namespace SA_ProductsReprised.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;

        public Repository(ProdDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);

            Save();
        }

        public T Get<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void Update(T entity)
        {
            Save();
        }

        private void Save()
        {
            Context.SaveChanges();
        }
    }
}
