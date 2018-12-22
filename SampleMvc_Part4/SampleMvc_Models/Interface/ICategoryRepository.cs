using SampleMvc_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMvc_Models.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByID(int categoryID);
    }
}
