using DataAccess.Entity;
using MedicSystem.Filters;
using MedicSystem.ViewModels.DoctorVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess.Service;

namespace MedicSystem.Controllers
{
    [AuthenticationFilter]
    public class DoctorController : BaseController<Doctor,ListDoctorVM,EditDoctorVM,DetailsDoctorVM,DoctorFilterVM>
    {
        public override void ExtraDelete(Doctor doctor)
        {
            AppointmentService service = new AppointmentService();
            List<Appointment> result = service.GetAll(r => r.Doctor.Id == doctor.Id).ToList();

            foreach (var item in result)
            {
                service.Delete(item);
            }

            UserService UserSevice = new UserService();
            UserSevice.Delete(UserSevice.GetById(doctor.UserId));
        }

        //public override List<Doctor> ListRepo(BaseRepo<Doctor> repo)
        //{
        //    DoctorRepo repoDoctor = new DoctorRepo();
        //    List<Doctor> result = repoDoctor.GetAll().ToList();
        //    return result;
        //}

        public override void PopulateItem(Doctor item, EditDoctorVM model)
        {
            if (item.UserId == 0)
            {
                UserService service = new UserService();
                User user = new User();

                item.Id = model.Id;
                user.Firstname = model.Firstname;
                user.Lastname = model.Lastname;
                user.Email = model.Email;
                user.Phone = model.Phone;
                user.Password = model.Password;
                item.Specialization = model.Specialization;
                item.Address = model.Address;
                user.IsAdmin = model.IsAdmin;

                service.Create(user);

                List<User> users = service.GetAll().OrderByDescending(u => u.Id).ToList();

                item.UserId = Convert.ToInt32(users[0].Id);
            }
            else
            {
                item.User.Firstname = model.Firstname;
                item.User.Lastname = model.Lastname;
                item.User.Email = model.Email;
                item.User.Phone = model.Phone;
                item.User.Password = model.Password;
                item.Specialization = model.Specialization;
                item.Address = model.Address;
                item.User.IsAdmin = model.IsAdmin;
            }
        }

        public override void PopulateModel(Doctor item, EditDoctorVM model)
        {
            model.Id = item.Id;
            model.Firstname = item.User.Firstname;
            model.Lastname = item.User.Lastname;
            model.Email = item.User.Email;
            model.Phone = item.User.Phone;
            model.Password = item.User.Password;
            model.Specialization = item.Specialization;
            model.Address = item.Address;
            model.IsAdmin = item.User.IsAdmin;
        }

        public override void PopulateModelDelete(Doctor item, DetailsDoctorVM model)
        {
            model.Id = item.Id;
            model.Firstname = item.User.Firstname;
            model.Lastname = item.User.Lastname;
            model.Email = item.User.Email;
            model.Phone = item.User.Phone;
            model.Specialization = item.Specialization;
            model.Address = item.Address;
            model.IsAdmin = item.User.IsAdmin;
        }

        public override BaseService<Doctor> SetService()
        {
            return new DoctorService();
        }
    }
}