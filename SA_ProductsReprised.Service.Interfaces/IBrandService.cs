using System;
using System.Collections.Generic;
using System.Text;

namespace SA_ProductsReprised.Service.Interfaces
{
    public interface IBrandService
    {
        IEnumerable<Dto.SA_Brand> GetAll();
        IEnumerable<Dto.SA_Brand> GetAllWithUnderCutters();
        Dto.SA_Brand Get(int id);
    }
}
