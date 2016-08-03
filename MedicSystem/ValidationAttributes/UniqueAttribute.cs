using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MedicSystem.Models;
namespace MedicSystem.ValidationAttributes
{
    public class UniqueAttribute : ValidationAttribute
    {
        private string entityTypeName;
        private string memberName;

        public UniqueAttribute(string entityTypeName)
        {
            this.entityTypeName = entityTypeName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            this.memberName = validationContext.MemberName;

            return base.IsValid(value, validationContext);
        }

        public override bool IsValid(object value)
        {
            AppointmentRepo AppointmentRepo = new AppointmentRepo();
            List<Appointment> result = AppointmentRepo.GetAll().ToList();

            foreach (var item in result)
            {
                if (item.Date.ToString() == value.ToString())
                {
                    this.ErrorMessage = "This appointment is already set by another patient!";
                    return false;
                }
            }

            return true;
        }
    }
}