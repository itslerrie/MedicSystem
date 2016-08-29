using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicSystemAPI.Models
{
    public class DoctorModel : BaseIdModel
    {
        public int UserId { get; set; }
        public string Specialization { get; set; }
        public string Address { get; set; }
    }
}