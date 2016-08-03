using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BaseRepo <T> where T : BaseEntity,new()
    {
        private MedicSystemDbContext<T> context;
        private DbSet<T> dbSet;

        public BaseRepo()
        {
            this.context = new MedicSystemDbContext<T>();
            this.dbSet = context.Set<T>();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter, int? page = null, int? pageSize = null)
        {
            IQueryable<T> result = dbSet;

            if (filter != null)
                result = dbSet.Where(filter);

            page = page ?? 1;
            pageSize = pageSize ?? 10;

            return result.OrderBy(i => i.Id).Skip(pageSize.Value * (page.Value - 1)).Take(pageSize.Value);

        }
        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
            if (filter == null)
                return dbSet.Count();

            return dbSet.Count(filter);
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);

        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public void Edit(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var dbEntry = context.Entry(entity);
            dbEntry.State = state;
        }
    }
}
