using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cash_Inspection.Models;
using Cash_Inspection.Controllers;
using System.Data;

using System.Net;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;





namespace Cash_Inspection.Models
{
    //Category Repositiry
    public class CategoryRepository: ICategoryRepository
    {
        public DataEntities _db;

        public CategoryRepository()
        {
            this._db = new DataEntities();
        }

        public CategoryRepository(DataEntities db)
        {
            this._db = db;
        }

        public IEnumerable<Category> GetAll(HttpContextBase http)
        {
            string id = http.User.Identity.GetUserId();
             var qu = from b in _db.CategoryDb where b.ApplicationUser.Id == id select b;
            return qu.ToList();
        }

        public Category Get(int id)
        {
            var result = _db.CategoryDb.Find(id);
            var qu = from b in _db.CategoryDb where b.Id == id select b;
            if (qu.ToList()[0] == null)
                return null;
            return result;  
        }

        public void Create(Category Category,System.Web.HttpContextBase HttpContext)
        {
            string ID = HttpContext.User.Identity.GetUserId();
            var qu = from b in _db.Users where b.Id == ID select b;
            _db.CategoryDb.Add(Category = new Category()
            {
                Id = Category.Id,
                Title = Category.Title,
                NumberofMoney = Category.NumberofMoney,
                ApplicationUser = qu.ToList()[0]
            });          
        }

        public void Update(Category Category)
        {
            _db.Entry(Category).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Category Category = _db.CategoryDb.Find(id);
            if (Category != null)
                _db.CategoryDb.Remove(Category);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Subcategory> GetAllSubcategory(Category cat)
        {
            var qu = from b in _db.SubcategoryDb where b.CategoryId == cat.Id select b;
            return qu.ToList();

        }
    }
}
