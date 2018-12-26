using SampleMvc_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMvc_Service.Interface
{
    public interface ICategoryService
    {
        IResult Create(Category instance);

        IResult Update(Category instance);

        IResult Delete(int categoryID);

        bool IsExist(int categoryID);

        Category GetByID(int categoryID);

        IEnumerable<Category> GetAll();

    }
}
