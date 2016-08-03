using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicSystem.ViewModels.AppointmentVM
{
    public class DetailsAppointmentVM : BaseVMId
    {
        public User Patient { get; set; }

        public Doctor Doctor { get; set; }

        [Display(Name = "Date:")]
        public DateTime Date { get; set; }

        [Display(Name = "Approved:")]
        public string IsApproved { get; set; }
    }
}