using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MedicSystem.ViewModels
{
    public abstract class FilterVM<T> : BaseFilter
        where T : BaseEntity
    {
        public abstract Expression<Func<T, bool>> GenerateFilter();
    }
}