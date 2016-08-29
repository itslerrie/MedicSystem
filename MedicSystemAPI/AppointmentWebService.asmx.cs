using DataAccess.Entity;
using MedicSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DataAccess.Service;

namespace MedicSystemAPI
{
    /// <summary>
    /// Summary description for AppointmentWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class AppointmentWebService : BaseWebService<Appointment, AppointmentModel >
    {
        public override void PopulateItem(Appointment item, AppointmentModel model)
        {
            item.Id = model.Id;
            item.Date = model.Date;
            item.DoctorId = model.DoctorId;
            item.IsApproved = model.IsApproved;
            item.UserId = model.UserId;
        }

        public override void PopulateModel(Appointment item, AppointmentModel model)
        {
            model.Id = item.Id;
            model.Date = item.Date;
            model.DoctorId = item.DoctorId;
            model.IsApproved = item.IsApproved;
            model.UserId = item.UserId;
        }

        public override BaseService<Appointment> SetService()
        {
            return new AppointmentService();
        }
    }
}
