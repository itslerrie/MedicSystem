using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Appointments = new List<Appointment>();
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }

        public Doctor doctors { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
