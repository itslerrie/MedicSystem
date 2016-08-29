using DataAccess.Entity;
using DataAccess.Service;
using MedicSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MedicSystemAPI
{
    /// <summary>
    /// Summary description for BaseWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public abstract class BaseWebService<T,M> : System.Web.Services.WebService 
        where T: BaseEntity, new() 
        where M: BaseIdModel, new()
    {
        public abstract BaseService<T> SetService();
        private BaseService<T> service;

        public BaseWebService()
        {
            service = SetService();
        }

        public abstract void PopulateItem(T item, M model);
        public abstract void PopulateModel(T item, M model);

        public virtual List<M> FillList(List<T> items)
        {
            List<M> models = new List<M>();

            foreach (var item in items)
            {
                M model = new M();

                PopulateModel(item, model);

                models.Add(model);
            }

            return models;
        }


        [WebMethod]
        public List<M> GetAll()
        {
            List<T> items = service.GetAll().ToList();
            return FillList(items);
        }

        [WebMethod]
        public M GetById(int id)
        {
            M model = new M();

            PopulateModel(service.GetById(id),model);

            return model;
        }

        [WebMethod]
        public void Create(M model)
        {
            T item = new T();

            PopulateItem(item, model);

            service.Create(item);
        }

        [WebMethod]
        public void Delete(M model)
        {
            T item = new T();

            PopulateItem(item,model);

            service.Delete(item);
        }

        [WebMethod]
        public void Edit(M model)
        {
            T item = service.GetById(model.Id);

            PopulateItem(item,model);

            service.Edit(item);
        }
    }
}
