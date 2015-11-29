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
        IdentityUnitOfWork UnitObj = new IdentityUnitOfWork();

        #region NO-POST-GET_Actions
                                                                                        /// <summary>
                                                                                        /// Вывод общих средств Аккаунта.
                                                                                        /// </summary>                                                                                       
                                                                                    public Nullable<decimal> TotalMoney()
                                                                                    {
                                                                                        return db.Users.Find(User.Identity.GetUserId()).TotalMoney;
                                                                                    }

                                                                                        /// <summary>
                                                                                        /// Cоставление и вывод Статистики.
                                                                                        /// </summary>
        


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
            Category category = qu.ToList()[0];
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryName = qu.ToList()[0].Title;
            ViewBag.ID = qu.ToList()[0].Id;

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
                UnitObj.Categories.Create(category,HttpContext);
                UnitObj.Save();
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
            Category category = db.CategoryDb.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,Title,NumberofMoney")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
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
            Category category = db.CategoryDb.Find(id);
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
            db.CategoryDb.Remove(category);
            db.SaveChanges();
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
