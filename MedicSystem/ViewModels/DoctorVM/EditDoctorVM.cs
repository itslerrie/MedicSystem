using HelthSystem.ValidationAtribute;
using MedicSystem.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicSystem.ViewModels.DoctorVM
{
    public class EditDoctorVM : BaseVMId
    {
        [Required(ErrorMessage = "Please enter your First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please repeat your Password")]
        [Display(Name = "Repeat your Password:")]
        [MatchValue("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Please enter your E-mail")]
        [UniqueEmail("Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Phone number")]
        public string Phone { get; set; }

        //[Required(ErrorMessage = "Please enter your Specialization")]
        public string Specialization { get; set; }

        //[Required(ErrorMessage = "Please enter your Address")]
        public string Address { get; set; }

        [Display(Name = "Admin:")]
        public bool IsAdmin { get; set; }

        public int UserId { get; set; }
    }
}