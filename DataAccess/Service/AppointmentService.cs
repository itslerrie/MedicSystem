using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.Service
{
    public class AppointmentService : BaseService<Appointment>
    {
        public override BaseRepo<Appointment> SetRepo()
        {
            return new AppointmentRepo();
        }
    }
}
