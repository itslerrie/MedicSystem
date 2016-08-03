using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Doctor : BaseEntity
    {

        public Doctor()
        {
            this.Appointments = new List<Appointment>();
        }

        [Key, ForeignKey ("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string Specialization { get; set; }
        public string Address { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
