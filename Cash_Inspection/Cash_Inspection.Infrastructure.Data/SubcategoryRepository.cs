using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Core;

namespace Cash_Inspection.Infrastructure.Data
{
    //Subcategory Repository
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private DataContext db;

        public SubcategoryRepository()
        {
            this.db = new DataContext();
        }

        public IEnumerable<Subcategory> GetSubcategoryList()
        {
            return db.DbSubcategory.ToList();
        }

        public Subcategory GetSubcategory(int id)
        {
            return db.DbSubcategory.Find(id);
        }

        public void Create(Subcategory Subcategory)
        {
            db.DbSubcategory.Add(Subcategory);
        }

        public void Update(Subcategory Subcategory)
        {
            db.Entry(Subcategory).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Subcategory Subcategory = db.DbSubcategory.Find(id);
            if (Subcategory != null)
                db.DbSubcategory.Remove(Subcategory);
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