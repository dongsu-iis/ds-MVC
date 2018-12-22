using SampleMvc_Models;
using SampleMvc_Models.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SampleMvc_Models.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public Product GetByID(int productID)
        {
            return this.Get(x => x.ProductID == productID);
        }

        public IEnumerable<Product> GetByCategory(int categoryID)
        {
            return this.GetAll().Where(x => x.CategoryID == categoryID);
        }


    }
}