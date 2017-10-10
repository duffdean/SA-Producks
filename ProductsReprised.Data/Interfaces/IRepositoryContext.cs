using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsReprised.Data.Interfaces
{
    public interface IRepositoryContext
    {
        IObjectSet<T> GetObjectSet<T>() where T : class;
        ObjectContext ObjectContext { get; } 
    }
}
