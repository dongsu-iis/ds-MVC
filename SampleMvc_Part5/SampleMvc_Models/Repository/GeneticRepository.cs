using SampleMvc_Models.Interface;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace SampleMvc_Models.Repository
{
    public class GenericRepository<Entity> : IRepository<Entity>
        where Entity : class
    {

        private DbContext Dbcontext { get; set; }

        public GenericRepository()
            : this(new NorthwindEntities())
        {

        }

        public GenericRepository(DbContext context)
        {
            Dbcontext = context ?? throw new ArgumentNullException("context");
        }

        public GenericRepository(ObjectContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            Dbcontext = new DbContext(context, true);
        }

        public void Create(Entity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                Dbcontext.Set<Entity>().Add(instance);
                SaveChanges();
            }
        }

        public void Update(Entity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                Dbcontext.Entry(instance).State = EntityState.Modified;
                SaveChanges();
            }
        }

        public void Delete(Entity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                Dbcontext.Entry(instance).State = EntityState.Deleted;
                SaveChanges();
            }
        }

        public Entity Get(Expression<Func<Entity, bool>> expression)
        {
            return Dbcontext.Set<Entity>().FirstOrDefault(expression);
        }

        public IQueryable<Entity> GetAll()
        {
            return Dbcontext.Set<Entity>().AsQueryable();
        }

        public void SaveChanges()
        {
            Dbcontext.SaveChanges();
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
                if (Dbcontext != null)
                {
                    Dbcontext.Dispose();
                    Dbcontext = null;
                }
            }
        }

    }
}