using DataAccess.Entity;
using MedicSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MedicSystem.ViewModels.UserVM
{
    public class UserFilterVM : FilterVM<User>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }
        [FilterByAttribute(DisplayName = "Email:")]
        public string Email { get; set; }

        public override Expression<Func<User, bool>> GenerateFilter()
        {
            return (u => (String.IsNullOrEmpty(Name) || u.Firstname.Contains(Name)) &&
                         (String.IsNullOrEmpty(Name) || u.Lastname.Contains(Name)) &&
                         (String.IsNullOrEmpty(Email) || u.Email.Contains(Email)));
        }
    }
}