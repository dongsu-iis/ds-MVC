using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleMvc_Models.Interface;

namespace SampleMvc_Models.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public Category GetByID(int categoryID)
        {
            return this.Get(x => x.CategoryID == categoryID);
        }
    }
}