using DataAccess.Entity;
using DataAccess.Repository;
using MedicSystem.Filters;
using MedicSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using DataAccess.Service;

namespace MedicSystem.Controllers
{
    [AuthenticationFilter]
    public abstract class BaseController<T, L, E, D, F> : Controller
        where T : BaseEntity, new()
        where E : BaseVMId, new()
        where D : BaseVMId, new()
        where L : BaseVMList<T, F>, new()
        where F : FilterVM<T>, new()
    {
        public abstract BaseService<T> SetService();
        //public abstract List<T> ListRepo(BaseService<T> repo);
        public abstract void PopulateItem(T item, E model);
        public abstract void PopulateModel(T item, E model);
        public abstract void PopulateModelDelete(T item, D model);

        public virtual void ExtraDelete(T item)
        {
        }

        public virtual void FillList(E model)
        {
        }

        public virtual void PopulateModel(L model)
        {
            BaseService<T> service = SetService();

            TryUpdateModel(model);

            Expression<Func<T, bool>> filter = model.Filter.GenerateFilter();
            model.Items = service.GetAll(filter, model.Pager.CurrentPage, model.Pager.PageSize).ToList();

            int resultCount = service.Count(filter);
            model.Pager.PagesCount = (int)Math.Ceiling(resultCount / (double)model.Pager.PageSize);
        }

        public ActionResult Index()
        {
            L model = new L();
            model.Pager = new PagerVM();
            model.Filter = new F();

            model.Pager.Prefix = "Pager.";
            model.Filter.Prefix = "Filter.";
            model.Filter.Pager = model.Pager;

            PopulateModel(model);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            E model = new E();

            FillList(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(E model)
        {
            if (!this.ModelState.IsValid)
            {
                FillList(model);
                return View(model);
            }

            BaseService<T> service = SetService();
            T newItem = new T();

            PopulateItem(newItem, model);

            service.Create(newItem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            BaseService<T> service = SetService();
            T item = service.GetById(id);

            D model = new D();

            PopulateModelDelete(item, model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(D model)
        {
            BaseService<T> service = SetService();
            T deletedItem = service.GetById(model.Id);

            service.Delete(deletedItem);

            ExtraDelete(deletedItem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            E model = new E();

            FillList(model);

            BaseService<T> service = SetService();
            T item = service.GetById(id);

            PopulateModel(item, model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(E model)
        {
            if (!this.ModelState.IsValid)
            {
                FillList(model);
                return View(model);
            }

            BaseService<T> service = SetService();
            T item = service.GetById(model.Id); ;

            PopulateItem(item, model);

            service.Edit(item);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            BaseService<T> service = SetService();
            T item = service.GetById(id);

            D model = new D();

            PopulateModelDelete(item, model);

            return View(model);
        }
    }
}