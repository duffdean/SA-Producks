using System;
using System.Collections.Generic;
using System.Text;

namespace SA_ProductsReprised.Service.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Dto.SA_Product> GetAll();
        IEnumerable<Dto.SA_Product> GetAllWithUnderCutters();
        Dto.SA_Product Get(int id);
    }
}
