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

namespace MedicSystem.ViewModels.AppointmentVM
{
    public class AppoitmentFilterVM : FilterVM<Appointment>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }

        public string Choosen { get; set; }
        public Array Choose = new string[] { "confirm", "decline", "pending" };

        public override Expression<Func<Appointment, bool>> GenerateFilter()
        {
            DoctorRepo repo = new DoctorRepo();
            Doctor doc = repo.GetById(AuthenticationManager.LoggedUser.Id);

            if (doc != null)
            {
                return (u => (u.DoctorId == AuthenticationManager.LoggedUser.Id || u.User.Id == AuthenticationManager.LoggedUser.Id) &&
                        (String.IsNullOrEmpty(Name) || u.User.Firstname.Contains(Name)) &&
                        (String.IsNullOrEmpty(Choosen) || u.IsApproved.ToLower().Equals(Choosen.ToLower())) &&
                        (String.IsNullOrEmpty(Name) || u.User.Lastname.Contains(Name)));
            }
            else
            {
                return (u => (u.DoctorId == AuthenticationManager.LoggedUser.Id || u.User.Id == AuthenticationManager.LoggedUser.Id) &&
                        (String.IsNullOrEmpty(Choosen) || u.IsApproved.ToLower().Equals(Choosen.ToLower())) &&
                        (String.IsNullOrEmpty(Name) || u.Doctor.User.Lastname.Contains(Name)));
            }
        }
    }
}