using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicSystemAPI.Models
{
    public class AppointmentModel:BaseIdModel
    {
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string IsApproved { get; set; }
    }
}