using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelthSystem.ValidationAtribute
{
    public class UniqueEmail : ValidationAttribute
    {
        private string targetProperty;

        public UniqueEmail(string targetProperty)
        {
            this.targetProperty = targetProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.targetProperty);
            var referenceProperty = (int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            UserRepo UserRepo = new UserRepo();
            List<User> users = UserRepo.GetAll().ToList();
            User editUser = UserRepo.GetById(referenceProperty);


            if (editUser != null)
            {
                foreach (var item in users)
                {
                    if (item.Email == value.ToString() && editUser.Email != value.ToString())
                    {
                        return new ValidationResult("This E-mail already exists!");
                    }
                }
            }
            else
            {
                foreach (var item in users)
                {
                    if (item.Email == value.ToString())
                    {
                        return new ValidationResult("This E-mail already exists!");
                    }
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