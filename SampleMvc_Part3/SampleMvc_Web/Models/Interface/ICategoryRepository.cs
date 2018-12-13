using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMvc_Web.Models.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByID(int categoryID);
    }
}
