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

        // GET: Subcategories
        public async Task<ActionResult> Index()
        {
            var subcategoryDb = db.SubcategoryDb.Include(s => s.Category);
            return View(await subcategoryDb.ToListAsync());
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
        public ActionResult Create(int id)
        {      
            ViewBag.id=id;
            return View(new Subcategory() { CategoryId = id ,Value=0 });
        }

        // POST: Subcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Value,CategoryId,Comment")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
               Category Cat= _Manager.Categories.Get(subcategory.CategoryId);                        
                _Manager.Subcategories.Create(subcategory, HttpContext);
                _Manager.Trans.CategoryToSubTransaction(HttpContext, Cat, subcategory);
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
