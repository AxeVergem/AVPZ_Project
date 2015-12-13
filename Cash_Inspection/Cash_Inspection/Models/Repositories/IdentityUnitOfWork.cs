
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
        private ResourcesRepository resourcesRepository;


        public IdentityUnitOfWork()
        {
            db = new DataEntities();
            resourcesRepository = new ResourcesRepository(db);
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
        public ResourcesRepository Trans
        {
            get
            {
                if (resourcesRepository == null)
                    resourcesRepository = new ResourcesRepository (db);
                return resourcesRepository;
            }
        }
        public void Save()
        {
            categoryRepository._db.SaveChanges();
            subcategoryRepository.db.SaveChanges();
            resourcesRepository._db.SaveChanges();
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
