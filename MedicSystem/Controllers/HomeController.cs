using DataAccess.Entity;
using DataAccess.Repository;
using MedicSystem.Filters;
using MedicSystem.Models;
using MedicSystem.ViewModels.DoctorVM;
using MedicSystem.ViewModels.HomeVM;
using MedicSystem.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();

        }

        [HttpGet]
        public ActionResult Create()
        {
            EditUserVM model = new EditUserVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EditUserVM model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            UserRepo repo = new UserRepo();
            User newItem = new User();

            newItem.Email = model.Email;
            newItem.Password = model.Password;
            newItem.Firstname = model.Firstname;
            newItem.Lastname = model.Lastname;
            newItem.Phone = model.Phone;


            repo.Create(newItem);

            return RedirectToAction("Login");
        }


        [HttpGet]
        public ActionResult LogIn()
        {
            return View();

        }

        [HttpPost]
        public ActionResult LogIn(LogInVM login)
        {
            AuthenticationManager.Authenticate(login.Email, login.Password);

            if (AuthenticationManager.LoggedUser == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Appointment");
            }
        }

        public ActionResult LogOut()
        {
            if (AuthenticationManager.LoggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }
            AuthenticationManager.Logout();

            return RedirectToAction("Login", "Home");
        }

        [AuthenticationFilter]
        [HttpGet]
        public ActionResult Details()
        {
            User user = AuthenticationManager.LoggedUser;

            DetailsUserVM details = new DetailsUserVM();

            details.Id = user.Id;
            details.Email = user.Email;
            details.Firstname = user.Firstname;
            details.Lastname = user.Lastname;
            details.Phone = user.Phone;

            return View(details);
        }

        [AuthenticationFilter]
        [HttpGet]
        public ActionResult Edit()
        {
            User user = AuthenticationManager.LoggedUser;

            DoctorRepo repo = new DoctorRepo();
            Doctor doctor = repo.GetById(user.Id);

            EditDoctorVM edit = new EditDoctorVM();

            edit.Id = user.Id;
            edit.Email = user.Email;
            edit.Password = user.Password;
            edit.Firstname = user.Firstname;
            edit.Lastname = user.Lastname;
            edit.Phone = user.Phone;
            edit.IsAdmin = AuthenticationManager.LoggedUser.IsAdmin;

            if (doctor != null)
            {
                edit.Specialization = doctor.Specialization;
                edit.Address = doctor.Address;
            }

            return View(edit);
        }

        [HttpPost]
        public ActionResult Edit(EditDoctorVM edit)
        {
            if (!this.ModelState.IsValid)
            {
                return View(edit);
            }

            UserRepo repo = new UserRepo();
            User user = new User();

            user.Id = edit.Id;
            user.Email = edit.Email ;
            user.Password = edit.Password;
            user.Firstname = edit.Firstname;
            user.Lastname = edit.Lastname;
            user.Phone = edit.Phone;
            user.IsAdmin = AuthenticationManager.LoggedUser.IsAdmin;

            repo.Edit(user);

            if (edit.Specialization != null)
            {
                DoctorRepo repoDoctor = new DoctorRepo();
                Doctor doctor = new Doctor();

                doctor.Specialization = edit.Specialization;
                doctor.Address = edit.Address;
                doctor.UserId = AuthenticationManager.LoggedUser.Id;

                repoDoctor.Edit(doctor);
            }

            AuthenticationManager.Authenticate(AuthenticationManager.LoggedUser.Email, AuthenticationManager.LoggedUser.Password);
            return RedirectToAction("Details", "Home");
        }
    }
}