using System.Collections.Generic;

namespace SA_ProductsReprised.Service.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Dto.SA_Category> GetAll();
        Dto.SA_Category Get(int id);
    }
}

