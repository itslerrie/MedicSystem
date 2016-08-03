using DataAccess.Entity;
using MedicSystem.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicSystem.ViewModels.AppointmentVM
{
    public class ListAppointmentVM : BaseVMList<Appointment,AppoitmentFilterVM>
    {
    }
}