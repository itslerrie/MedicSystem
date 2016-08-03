using DataAccess.Entity;
using MedicSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MedicSystem.ViewModels.DoctorVM
{
    public class DoctorFilterVM : FilterVM<Doctor>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }
        [FilterByAttribute(DisplayName = "Email:")]
        public string Email { get; set; }

        public override Expression<Func<Doctor, bool>> GenerateFilter()
        {
            return (d => (String.IsNullOrEmpty(Name) || d.User.Lastname.Contains(Name)) &&
                         (String.IsNullOrEmpty(Email) || d.User.Email.Contains(Email)));
        }
    }
}