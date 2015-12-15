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
   public class ResourcesRepository:IResourcesRepository
    {
        public DataEntities _db;
        IdentityUnitOfWork _Manager;
        public  ResourcesRepository()
        {
            this._db = new DataEntities();
            _Manager = new IdentityUnitOfWork();
        }
        public ResourcesRepository(DataEntities db)
        {
            this._db = db;
        }
        public  void TotalToCategoryTransaction(HttpContextBase http, Category category)
        {
          string id=  http.User.Identity.GetUserId();

            ApplicationUser user = _db.Users.Find(id);                
            Category categoryForTrans = _db.CategoryDb.Find(category.Id);
            user.TotalMoney -= categoryForTrans.NumberofMoney; 
        }
        public void CategoryToSubTransactionAdd(HttpContextBase http, Category category, Subcategory subcategory)
        {
            string id = http.User.Identity.GetUserId();
            Category categoryForTrans = _db.CategoryDb.Find(category.Id);
            category.NumberofMoney -= subcategory.Value;
        }
        public void CategoryToSubTransactionRemove(HttpContextBase http, Category category, Subcategory subcategory)
        {
            string id = http.User.Identity.GetUserId();
            Category categoryForTrans = _db.CategoryDb.Find(category.Id);
            category.NumberofMoney += subcategory.Value;
        }
        public void ImplUserResources(HttpContextBase http,UserLogEntry entry)
        {
            string ID = http.User.Identity.GetUserId();       
            
             ApplicationUser user= _db.Users.Find(ID);
             user.TotalMoney += entry.Value;
            _db.Entry(user).State = EntityState.Modified;
        }
        public void CreateLogEntry(HttpContextBase HttpContext,UserLogEntry Entry)
        {
            UserLogEntry UsEntry = new UserLogEntry()
            {
                Date = DateTime.Now,
                Comment = Entry.Comment,
                Value = Entry.Value,
                UserId = HttpContext.User.Identity.GetUserId(),
                Id=Entry.Id
            };
            _db.UserLog.Add(UsEntry);           
        }
        public IEnumerable<UserLogEntry> GetUserLog(HttpContextBase http)
        {
            string userID = http.User.Identity.GetUserId();
            List<UserLogEntry> log = new List<UserLogEntry>();
            var qu = from b in _db.UserLog where b.UserId == userID select b;
            log = qu.ToList();
            return log;
                      
        }
    }
}
