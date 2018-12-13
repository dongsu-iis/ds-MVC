using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleMvc_Web.Models.Interface;

namespace SampleMvc_Web.Models.Repository
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