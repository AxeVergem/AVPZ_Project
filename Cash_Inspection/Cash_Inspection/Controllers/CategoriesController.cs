using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cash_Inspection.Models;
using Microsoft.AspNet.Identity;

namespace Cash_Inspection.Controllers
{
    
    public class CategoriesController : Controller
    {
        
        private DataEntities db = new DataEntities();
        IdentityUnitOfWork _Manager= new IdentityUnitOfWork();

        #region NO-POST-GET_Actions
                                                                                        /// <summary>
                                                                                        /// Вывод общих средств Аккаунта.
                                                                                        /// </summary>                                                                                       
                                                                                    public Nullable<decimal> TotalMoney()
                                                                                    {
                                                                                        return db.Users.Find(User.Identity.GetUserId()).TotalMoney;
                                                                                    }

        


        #endregion



        public ActionResult Index()
        {
            ViewBag.TotalMoney = db.Users.Find(User.Identity.GetUserId()).TotalMoney;
            string id = User.Identity.GetUserId();
            var q = from b in db.CategoryDb where b.ApplicationUser.Id == id select b;

            return View(q.ToList());
            
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            var qu = from b in db.CategoryDb where b.Id == id select b;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _Manager.Categories.Get((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryName = _Manager.Categories.Get((int)id).Title;
            ViewBag.ID = _Manager.Categories.Get((int)id).Id; 
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,NumberofMoney")] Category category)
        {
            
            if (ModelState.IsValid)
            {
                _Manager.Categories.Create(category,HttpContext);
                _Manager.Trans.TotalToCategoryTransaction(HttpContext, category);
                _Manager.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _Manager.Categories.Get((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] Category category)
        {
            if (ModelState.IsValid)
            {
                _Manager.Categories.Update(category);
                _Manager.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _Manager.Categories.Get((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.CategoryDb.Find(id);
            _Manager.Categories.Delete(id);
            _Manager.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
