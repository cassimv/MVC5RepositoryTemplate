using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template.Data
{
    public interface IRepository<TEntity> where TEntity:class 
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> Find(Func<TEntity, bool> predicate);
    }
}
