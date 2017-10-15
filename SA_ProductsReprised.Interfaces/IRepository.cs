using System.Linq;

namespace SA_ProductsReprised.Repositoty.Interfaces
{
    public interface IRepository<T>
    {
        T Get<TKey>(TKey id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
    }
}
