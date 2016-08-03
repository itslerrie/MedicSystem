using DataAccess.Entity;
using MedicSystem.Controllers;
using MedicSystem.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;

namespace MedicSystem.Controllers
{
    public class UserController : BaseController<User, ListUserVM, EditUserVM, DetailsUserVM,UserFilterVM>
    {
        public override void ExtraDelete(User patient)
        {
            AppointmentRepo repo = new AppointmentRepo();
            List<Appointment> result = repo.GetAll(r => r.Doctor.Id == patient.Id).ToList();

            foreach (var item in result)
            {
                repo.Delete(item);
            }
        }

        public override List<User> ListRepo(BaseRepo<User> repo)
        {
            List<User> result = repo.GetAll().ToList();

            return result;
        }

        public override void PopulateItem(User item, EditUserVM model)
        {
            item.Id = model.Id;
            item.Firstname = model.Firstname;
            item.Lastname = model.Lastname;
            item.Email = model.Email;
            item.Phone = model.Phone;
            item.Password = model.Password;
            item.IsAdmin = false;
        }

        public override void PopulateModel(User item, EditUserVM model)
        {
            model.Id = item.Id;
            model.Firstname = item.Firstname;
            model.Lastname = item.Lastname;
            model.Email = item.Email;
            model.Phone = item.Phone;
            model.Password = item.Password;
        }

        public override void PopulateModelDelete(User item, DetailsUserVM model)
        {
            model.Id = item.Id;
            model.Firstname = item.Firstname;
            model.Lastname = item.Lastname;
            model.Email = item.Email;
            model.Phone = item.Phone;
        }

        public override BaseRepo<User> SetRepo()
        {
            return new UserRepo();
        }
    }
}