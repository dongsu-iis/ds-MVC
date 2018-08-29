using System;
using System.Linq;

namespace SampleMvc_Web.Models.Interface
{
    interface IProductRepository : IDisposable
    {
        void Create(Product instance);

        void Update(Product instance);

        void Delete(Product instance);

        Product Get(int productId);

        IQueryable<Product> GetAll();

        void SaveChanges();
    }
}
