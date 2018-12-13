using System;
using System.Linq;
using System.Linq.Expressions;

namespace SampleMvc_Web.Models.Interface
{
   public interface IRepository<Entity> : IDisposable
        where Entity : class
    {
        void Create(Entity instance);

        void Update(Entity instance);

        void Delete(Entity instance);

        Entity Get(Expression<Func<Entity,bool>> expression);

        IQueryable<Entity> GetAll();

        void SaveChanges();
    }
}
