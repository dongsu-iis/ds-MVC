using System;
using System.Linq;

namespace SampleMvc_Web.Models.Interface
{
    interface ICategoryRepository : IDisposable
    {
        void Create(Category instance);

        void Update(Category instance);

        void Delete(Category instance);

        Category Get(int categoryId);

        IQueryable<Category> GetAll();

        void SaveChanges();
    }
}
