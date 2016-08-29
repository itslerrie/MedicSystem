using DataAccess.Entity;
using MedicSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MedicSystem.Models;
using System.Reflection;
using DataAccess.Repository;
using System.Web.Mvc;

namespace MedicSystem.ViewModels.AppointmentVM
{
    public class AppoitmentFilterVM : FilterVM<Appointment>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }
        
        public string Status { get; set; }

        [FilterDropDownAttribute(DisplayName = "Status", TargetProperty = "Status")]
        public List<SelectListItem> StatusListItems { get; set; }

        public AppoitmentFilterVM()
        {
            StatusListItems = new List<SelectListItem> { new SelectListItem { Text = "Confirmed", Value = "confirm" },
                                                                                new SelectListItem { Text = "Decline", Value = "decline" },
                                                                                new SelectListItem { Text = "Pending", Value = "pending" }
           };
        }

        public override Expression<Func<Appointment, bool>> GenerateFilter()
        {
            DoctorRepo repo = new DoctorRepo();
            Doctor doc = repo.GetById(AuthenticationManager.LoggedUser.Id);

            if (doc != null)
            {
                return (u => (u.DoctorId == AuthenticationManager.LoggedUser.Id || u.User.Id == AuthenticationManager.LoggedUser.Id) &&
                        (String.IsNullOrEmpty(Name) || u.User.Firstname.Contains(Name)) &&
                        (String.IsNullOrEmpty(Status) || u.IsApproved.ToLower().Equals(Status.ToLower())) &&
                        (String.IsNullOrEmpty(Name) || u.User.Lastname.Contains(Name)));
            }
            else
            {
                return (u => (u.DoctorId == AuthenticationManager.LoggedUser.Id || u.User.Id == AuthenticationManager.LoggedUser.Id) &&
                        (String.IsNullOrEmpty(Status) || u.IsApproved.ToLower().Equals(Status.ToLower())) &&
                        (String.IsNullOrEmpty(Name) || u.Doctor.User.Lastname.Contains(Name)));
            }
        }
    }
}