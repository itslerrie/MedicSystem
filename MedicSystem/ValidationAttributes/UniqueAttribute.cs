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
        private string targetProperty;

        public UniqueAttribute(string targetProperty)
        {
            this.targetProperty = targetProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.targetProperty);
            var referenceProperty = (int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            AppointmentRepo appointmentRepo = new AppointmentRepo();
            List<Appointment> all = appointmentRepo.GetAll().ToList();
            List<Appointment> result = new List<Appointment>();

            foreach (var item in all)
            {
                if (item.Doctor.UserId == referenceProperty)
                {
                    result.Add(item);
                }
            }

            foreach (var item in result)
            {
                if (item.Date.ToString() == value.ToString())
                {
                    return new ValidationResult("This Appointment is already set by another patient!");
                }
            }

            return base.IsValid(value, validationContext);
        }

        public override bool IsValid(object value)
        {
            return String.IsNullOrEmpty(this.ErrorMessage);
        }
    }
}