
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
using System.Threading.Tasks;

namespace Cash_Inspection.Models
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private DataEntities db;
        private CategoryRepository categoryRepository;
        private SubcategoryRepository subcategoryRepository;


        public IdentityUnitOfWork()
        {
            db = new DataEntities();

            categoryRepository = new CategoryRepository(db);
            subcategoryRepository = new SubcategoryRepository(db);
        }
        public CategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public SubcategoryRepository Subcategories
        {
            get
            {
                if (subcategoryRepository == null)
                    subcategoryRepository = new SubcategoryRepository(db);
                return subcategoryRepository;
            }
        }
        public void Save()
        {
            categoryRepository._db.SaveChanges();
            subcategoryRepository.db.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    categoryRepository.Dispose();
                    subcategoryRepository.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
