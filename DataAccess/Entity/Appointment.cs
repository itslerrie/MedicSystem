using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Appointment : BaseEntity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        
        public DateTime Date { get; set; }
        public string IsApproved { get; set; }
    }
}
