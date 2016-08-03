using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicSystem.ViewModels.HomeVM
{
    public class LogInVM
    {
        [Required(ErrorMessage = "Please enter a Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a Password")]
        public string Password { get; set; }
    }
}