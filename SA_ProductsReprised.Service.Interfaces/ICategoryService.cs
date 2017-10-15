using System.Collections.Generic;

namespace SA_ProductsReprised.Service.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Dto.SA_Category> GetAll();
        List<Dto.SA_Category> GetAllWithUnderCutters();
        Dto.SA_Category Get(int id);
    }
}

