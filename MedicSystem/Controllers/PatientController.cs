using DataAccess.Entity;
using DataAccess.Repository;
using MedicSystem.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MedicSystem.Controllers
{
    public class PatientController : BaseController<User,ListUserVM,EditUserVM,DetailsUserVM,UserFilterVM>
    {
        public override void PopulateModel(ListUserVM model)
        {
            DoctorRepo doctorRepo = new DoctorRepo();
            List<Doctor> doctors = doctorRepo.GetAll().ToList();

            UserRepo userRepo = new UserRepo();
            List<User> users = userRepo.GetAll().ToList();

            foreach (var item in doctors)
            {
                users.Remove(userRepo.GetById(item.UserId));
            }

            TryUpdateModel(model);

            Expression<Func<User, bool>> filter = model.Filter.GenerateFilter();
            model.Items = userRepo.GetItems(users, filter, model.Pager.CurrentPage, model.Pager.PageSize).ToList();

            int resultCount = userRepo.CountItems(users, filter);
            model.Pager.PagesCount = (int)Math.Ceiling(resultCount / (double)model.Pager.PageSize);
        }

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
            DoctorRepo doctorRepo = new DoctorRepo();
            UserRepo userRepo = new UserRepo();
            List<User> patients = userRepo.GetAll().ToList();
            List<Doctor> doctors = doctorRepo.GetAll().ToList();

            foreach (var doctor in doctors)
            {
                patients.Remove(userRepo.GetById(doctor.UserId));
            }

            return patients;
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