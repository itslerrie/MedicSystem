using MedicSystem.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicSystem.ViewModels.AppointmentVM
{ 
    public class EditAppointmentVM : BaseVMId
    {
        [Required(ErrorMessage = "Please enter a Doctor")]
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Please enter Date")]
        [UniqueAttribute("DoctorId")]
        public DateTime Date { get; set; }

        public List<SelectListItem> ListDoctors { get; set; }
    }
}