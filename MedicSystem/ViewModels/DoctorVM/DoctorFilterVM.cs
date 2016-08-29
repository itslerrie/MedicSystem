using DataAccess.Entity;
using MedicSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MedicSystem.ViewModels.DoctorVM
{
    public class DoctorFilterVM : FilterVM<Doctor>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }
        [FilterByAttribute(DisplayName = "Email:")]
        public string Email { get; set; }

        public string Status { get; set; }

        [FilterDropDownAttribute(DisplayName = "Status", TargetProperty = "Status")]
        public List<SelectListItem> StatusListItems { get; set; }

        public DoctorFilterVM()
        {
            StatusListItems = new List<SelectListItem> { new SelectListItem {  Text= "True", Value = "true" },
                                                                                new SelectListItem { Text = "False", Value = "false" }
           };
        }

        public override Expression<Func<Doctor, bool>> GenerateFilter()
        {
            return (d => (String.IsNullOrEmpty(Name) || d.User.Lastname.Contains(Name)) &&
                         (String.IsNullOrEmpty(Status) || d.User.IsAdmin.ToString() == Status) &&
                         (String.IsNullOrEmpty(Email) || d.User.Email.Contains(Email)));
        }
    }
}