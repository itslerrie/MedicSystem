using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicSystemAPI.Models
{
    public class UserModel:BaseIdModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
    }
}