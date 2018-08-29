using SampleMvc_Web.Models.Interface;
using System;
using System.Data.Entity;
using System.Linq;

namespace SampleMvc_Web.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected NorthwindEntities db { get; private set; }

        public ProductRepository()
        {
            db = new NorthwindEntities();
        }

        public void Create(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Products.Add(instance);
                SaveChanges();
            }
        }

        public void Update(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Modified;
                SaveChanges();
            }
        }

        public void Delete(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Deleted;
                SaveChanges();
            }
        }

        public Product Get(int productId)
        {
            return db.Products.FirstOrDefault(x => x.ProductID == productId);
        }

        public IQueryable<Product> GetAll()
        {
            return db.Products.OrderBy(x => x.ProductID);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

    }
}