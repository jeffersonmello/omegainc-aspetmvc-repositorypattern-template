using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OmegaInc.Common.Repository;
using OmegaInc.MultiPorpose.CoreData.Context;
using OmegaInc.MultiPorpose.Data.Example;
using OmegaInc.MultiPorpose.Repository.Entity.Example;
using OmegaInc.MultiPorpose.WEB.AutoMapper;
using OmegaInc.MultiPorpose.WEB.ViewModels.Example;

namespace OmegaInc.MultiPorpose.WEB.Controllers
{
    public class UserController : Controller
    {
        private IGenericRepository<User, int> repo = new UserRepository(new DataContext());

        // GET: User
        public ActionResult Index()
        {
            return View(AutoMapperManager.Instance.Mapper.Map<List<User>, List<UserIndexViewModel>>(repo.Select()));
        }

        // GET All for jquery bootgrid
        public JsonResult GetAll(string searchPhrase, int current = 1, int rowCount = 10)
        {
            // Ordenacao
            string columnKey = Request.Form.AllKeys.Where(k => k.StartsWith("sort")).First();
            string order = Request[columnKey];
            string field = columnKey.Replace("sort[", String.Empty).Replace("]", String.Empty);

            string fieldOrdened = String.Format("{0} {1}", field, order);
            fieldOrdened = fieldOrdened.Replace("Description", String.Empty);

            List<User> obj = repo.Select();


            List<User> paginado = obj.OrderBy(fieldOrdened).Skip((current - 1) * rowCount).Take(rowCount).ToList();

            List<UserIndexViewModel> viewModel = AutoMapperManager.Instance.Mapper.Map<List<User>, List<UserIndexViewModel>>(paginado);

            return Json(new
            {
                rows = viewModel,
                current = current,
                rowCount = rowCount,
                total = obj.Count()
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User obj = repo.SelectById(id.Value);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapperManager.Instance.Mapper.Map<User, UserIndexViewModel>(obj));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id,Name,Email")] UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User obj = AutoMapperManager.Instance.Mapper.Map<UserViewModel, User>(viewModel);
                repo.Insert(obj);

                return Json(new { resultado = true, message = "Registro criado com sucesso!" });
            }
            else
            {
                IEnumerable<ModelError> erros = ModelState.Values.SelectMany(item => item.Errors);

                return Json(new { resultado = false, message = erros });
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User obj = repo.SelectById(id.Value);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapperManager.Instance.Mapper.Map<User, UserViewModel>(obj));
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "Id,Name,Email")] UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User obj = AutoMapperManager.Instance.Mapper.Map<UserViewModel, User>(viewModel);
                repo.Edit(obj);

                return Json(new { resultado = true, message = "Registro atualizado com sucesso!" });
            }
            else
            {
                IEnumerable<ModelError> erros = ModelState.Values.SelectMany(item => item.Errors);

                return Json(new { resultado = false, message = erros });
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User obj = repo.SelectById(id.Value);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapperManager.Instance.Mapper.Map<User, UserIndexViewModel>(obj));
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                repo.DeleteById(id);
                return Json(new { resultado = true, message = "Registro deletado com sucesso!" });
            }
            catch (Exception e)
            {
                return Json(new { resultado = false, message = e.Message });
            }
        }
    }
}
