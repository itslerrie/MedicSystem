using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicSystem.ViewModels.UserVM
{
    public class DetailsUserVM : BaseVMId
    {
        [Display(Name = "Firstname:")]
        public string Firstname { get; set; }

        [Display(Name = "Lastname:")]
        public string Lastname { get; set; }

        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Display(Name = "Phone number:")]
        public string Phone { get; set; }

    }
}