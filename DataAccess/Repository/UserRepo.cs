using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepo : BaseRepo<User>
    {
        public IQueryable<User> GetItems(List<User> source, Expression<Func<User, bool>> filter, int? page = null, int? pageSize = null)
        {
            IQueryable<User> result = source.AsQueryable<User>();

            if (filter != null)
                result = result.Where(filter);

            page = page ?? 1;
            pageSize = pageSize ?? 10;

            return result.OrderBy(i => i.Id).Skip(pageSize.Value * (page.Value - 1)).Take(pageSize.Value);

        }

        public int CountItems(List<User> source, Expression<Func<User, bool>> filter)
        {
            IQueryable<User> result = source.AsQueryable<User>();

            if (filter == null)
                return result.Count();

            return result.Count(filter);
        }
    }
}
