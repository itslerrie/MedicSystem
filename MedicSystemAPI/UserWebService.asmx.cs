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
    /// Summary description for UserWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class UserWebService : BaseWebService<User, UserModel>
    {

        public override void PopulateItem(User item, UserModel model)
        {
            item.Id = model.Id;
            item.Firstname = model.Firstname;
            item.Email = model.Email;
            item.IsAdmin = model.IsAdmin;
            item.Lastname = model.Lastname;
            item.Password = model.Password;
            item.Phone = model.Phone;
        }

        public override void PopulateModel(User item, UserModel model)
        {
            model.Id = item.Id;
            model.Firstname = item.Firstname;
            model.Email = item.Email;
            model.IsAdmin = item.IsAdmin;
            model.Lastname = item.Lastname;
            model.Password = item.Password;
            model.Phone = item.Phone;
        }

        public override BaseService<User> SetService()
        {
            return new UserService();
        }
    }
}
