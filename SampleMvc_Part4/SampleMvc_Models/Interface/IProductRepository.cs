using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMvc_Models.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByID(int productID);

        IEnumerable<Product> GetByCategory(int categoryID);
    }
}
