using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Cash_Inspection.Models;
using Microsoft.AspNet.Identity;



namespace Cash_Inspection.Models
{
    //Subcategory Repository
    public class SubcategoryRepository :ISubcategoryRepository
    {
        public DataEntities db;

        public SubcategoryRepository()
        {
            this.db = new DataEntities();
        }

        public SubcategoryRepository(DataEntities db)
        {
            this.db = db;
        }

        public IEnumerable<Subcategory> GetAll(System.Web.HttpContextBase http,Category category)
        { string ID = http.User.Identity.GetUserId();
            var qu = from b in db.SubcategoryDb where b.CategoryId == category.Id && category.ApplicationUser.Id ==ID  select b;
            return qu.ToList();
        }
        public Subcategory Get(int id)
        {
            return db.SubcategoryDb.Find(id);
        }

        public void Create(Subcategory Subcategory,System.Web.HttpContextBase http)
        {
            db.SubcategoryDb.Add(Subcategory = new Subcategory()
            {
                Id = Subcategory.Id,
                Title = Subcategory.Title,
                Value = Subcategory.Value,
                Date = DateTime.Now,
                CategoryId = Subcategory.CategoryId,
                Comment = Subcategory.Comment,
      
                UserId = http.User.Identity.GetUserId()
                
            });
            db.SubcategoryDb.Add(Subcategory);
        }

        public void Update(Subcategory Subcategory)
        {
            db.Entry(Subcategory).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Subcategory Subcategory = db.SubcategoryDb.Find(id);
            if (Subcategory != null)
                db.SubcategoryDb.Remove(Subcategory);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}