using SampleMvc_Web.Models.Interface;
using System;
using System.Data.Entity;
using System.Linq;

namespace SampleMvc_Web.Models.Repository
{
    public class CategoryRepository : ICategoryRepository

    {
        protected NorthwindEntities db { get; private set; }

        public CategoryRepository()
        {
            db = new NorthwindEntities();
        }

        public void Create(Category instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Categories.Add(instance);
                SaveChanges();
            }
        }

        public void Update(Category instance)
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

        public void Delete(Category instance)
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

        public Category Get(int categoryId)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryID == categoryId);
        }

        public IQueryable<Category> GetAll()
        {
            return db.Categories.OrderBy(x => x.CategoryID);
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