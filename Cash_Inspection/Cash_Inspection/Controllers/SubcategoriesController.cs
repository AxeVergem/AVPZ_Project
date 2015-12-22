using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cash_Inspection.Models;

using Microsoft.AspNet.Identity;

namespace Cash_Inspection.Controllers
{
    public class SubcategoriesController : Controller
    {
        private DataEntities db = new DataEntities();
        IdentityUnitOfWork _Manager = new IdentityUnitOfWork();

        public JsonResult ColumnDiogram(int id)
        {                  
           List<Subcategory> list= new List<Subcategory>();
            var qu = from b in db.SubcategoryDb where b.CategoryId == id select b;             
            return Json(new { Countries =qu.ToList() }, JsonRequestBehavior.AllowGet );  
        }

        // GET: Subcategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategory subcategory = await db.SubcategoryDb.FindAsync(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        // GET: Subcategories/Create
        public ActionResult CreateImp(int id)
        {      
            ViewBag.id=id;
            return View(new Subcategory() { CategoryId = id});
        }

        // POST: Subcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateImp([Bind(Include = "Id,Title,Value,CategoryId,Comment")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                 
               Category Cat= _Manager.Categories.Get(subcategory.CategoryId);
                if (subcategory.Value >Cat.NumberofMoney)
                {
                    ViewBag.ResourcesLessError = "Не возможно провести операцию,у вас не хватает средств на проиндексированном счету категории";
                    RedirectToAction("Create", "Subcategories");
                }
                else
                {
                    _Manager.Subcategories.CreateImp(subcategory, HttpContext);
                    
                    _Manager.Trans.CategoryToSubTransactionAdd(HttpContext, Cat, subcategory);
                    _Manager.Save();
                    return RedirectToAction("Index");
                }                  

            }             
            return View(subcategory);
        }
        public ActionResult CreateUmp(int id)
        {
            ViewBag.id = id;
            return View(new Subcategory() { CategoryId = id });

        }
               [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUmp([Bind(Include = "Id,Title,Value,CategoryId,Comment")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                
               Category Cat= _Manager.Categories.Get(subcategory.CategoryId);         
                    ViewBag.ResourcesLessError = "Не возможно провести операцию,у вас не хватает средств на проиндексированном счету категории";
                    RedirectToAction("Create", "Subcategories");   
                    _Manager.Subcategories.CreateUmp(subcategory, HttpContext);
                
                _Manager.Trans.TotalToCategoryTransThowTheCat(HttpContext,Cat,subcategory.Value)   ;
                _Manager.Trans.CategoryToSubTransactionRemove(HttpContext, Cat, subcategory);
                    _Manager.Save();
                    return RedirectToAction("Index");
               

            }             
            return View(subcategory);
        }
        // GET: Subcategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategory subcategory = await db.SubcategoryDb.FindAsync(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        // POST: Subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Subcategory subcategory = await db.SubcategoryDb.FindAsync(id);
            db.SubcategoryDb.Remove(subcategory);
            await db.SaveChangesAsync();
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
