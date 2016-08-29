using DataAccess.Entity;
using MedicSystem.Controllers;
using MedicSystem.ViewModels.AppointmentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;
using MedicSystem.Models;
using DataAccess.Service;

namespace MedicSystem.Controllers
{
    public class AppointmentController : BaseController<Appointment, ListAppointmentVM, EditAppointmentVM, DetailsAppointmentVM,AppoitmentFilterVM>
    {

        //public override List<Appointment> ListRepo(BaseRepo<Appointment> repo)
        //{
        //    List<Appointment> result = new List<Appointment>();
        //    result = repo.GetAll(r => r.DoctorId == AuthenticationManager.LoggedUser.Id || r.User.Id == AuthenticationManager.LoggedUser.Id).ToList();

        //    return result;
        //}

        public override void FillList(EditAppointmentVM model)
        {
            UserService serviceUser = new UserService();
            DoctorService serviceDoctor = new DoctorService();
            List<Doctor> doctors = serviceDoctor.GetAll().ToList();
            List<User> result = new List<User>();

            foreach (var item in doctors)
            {
                result.Add(serviceUser.GetById(item.User.Id));
            }

            model.ListDoctors = new List<SelectListItem>();
            foreach (var item in result)
            {
                model.ListDoctors.Add(new SelectListItem()
                {
                    Text ="Dr. " + item.Lastname,
                    Value = item.Id.ToString()
                });
            }

            model.ListDoctors[0].Selected = true;
        }

        public override void PopulateItem(Appointment item, EditAppointmentVM model)
        {
            item.Id = model.Id;
            item.UserId = AuthenticationManager.LoggedUser.Id;
            item.DoctorId = model.DoctorId;
            item.Date = model.Date;
            item.IsApproved = "Pending";
        }

        public override void PopulateModel(Appointment item, EditAppointmentVM model)
        {
            model.Id = item.Id;
            model.DoctorId = item.DoctorId;
            model.Date = item.Date;
        }

        public override void PopulateModelDelete(Appointment item, DetailsAppointmentVM model)
        {
            model.Id = item.Id;
            model.Patient = item.User;
            model.Doctor = item.Doctor;
            model.Date = item.Date;
            model.IsApproved = item.IsApproved;
        }

        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            AppointmentService service = new AppointmentService();
            Appointment item = service.GetById(id);

            DetailsAppointmentVM model = new DetailsAppointmentVM();

            PopulateModelDelete(item, model);

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeStatus(DetailsAppointmentVM model)
        {
            AppointmentService service = new AppointmentService();
            Appointment item = service.GetById(model.Id);

            item.IsApproved = model.IsApproved;
            service.Edit(item);

            return RedirectToAction("Index");
        }

        public override BaseService<Appointment> SetService()
        {
            return new AppointmentService();
        }
    }
}