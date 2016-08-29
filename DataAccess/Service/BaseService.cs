using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public abstract class BaseService<T> where T: BaseEntity,new()
    {
        private BaseRepo<T> repo;

        public abstract BaseRepo<T> SetRepo();

        public BaseService()
         {
            repo = SetRepo();
         }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter, int? page = null, int? pageSize = null)
        {
            return repo.GetAll(filter,page,pageSize);
        }

        public IQueryable<T> GetAll()
        {
            return repo.GetAll();
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
            return repo.Count(filter);
        }

        public T GetById(object id)
        {
            return repo.GetById(id);
        }

        public void Create(T entity)
        {
            repo.Create(entity);
        }

        public void Delete(T entity)
        {
            repo.Delete(entity);
        }

        public void Edit(T entity)
        {
            repo.Edit(entity);
        }
    }
}
