using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.Service
{
    public class DoctorService : BaseService<Doctor>
    {
        public override BaseRepo<Doctor> SetRepo()
        {
            return new DoctorRepo();
        }
    }
}
