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
    /// Summary description for DoctorWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class DoctorWebService :BaseWebService<Doctor, DoctorModel>
    {

        public override void PopulateItem(Doctor item, DoctorModel model)
        {
            item.Id = model.Id;
            item.UserId = model.UserId;
            item.Specialization = model.Specialization;
            item.Address = model.Address;
        }

        public override void PopulateModel(Doctor item, DoctorModel model)
        {
            model.Id = item.Id;
            model.UserId = item.UserId;
            model.Specialization = item.Specialization;
            model.Address = item.Address;
        }

        public override BaseService<Doctor> SetService()
        {
            return new DoctorService();
        }
    }
}
