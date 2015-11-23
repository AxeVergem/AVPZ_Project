using Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Cash_Inspection.Infrastructure.Data
{
    //Category Repositiry
    public class CategoryRepository:ICategoryRepository
    {
        private DataContext db;

        public CategoryRepository()
        {
            this.db = new DataContext();
        }

        public IEnumerable<Category> GetCategoryList()
        {
            return db.DbCategory.ToList();
        }

        public Category GetCategory(int id)
        {
            return db.DbCategory.Find(id);
        }

        public void Create(Category Category)
        {
            db.DbCategory.Add(Category);
        }

        public void Update(Category Category)
        {
            db.Entry(Category).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Category Category = db.DbCategory.Find(id);
            if (Category != null)
                db.DbCategory.Remove(Category);
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
