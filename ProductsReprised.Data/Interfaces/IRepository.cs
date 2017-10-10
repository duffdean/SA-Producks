using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;

namespace ProductsReprised.Data.Interfaces
{
    public interface IRepository<T>
    {
        //void Add(T entity);        
        //void Delete(T entity);
        //void Attach(T entity);
        //IList<T> GetAll();
        //T GetSingle(Expression<Func<T, bool>> whereCondition);
        //IList<T> GetAll(Expression<Func<T, bool>> whereCondition);

        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll { get; }
    }
}
