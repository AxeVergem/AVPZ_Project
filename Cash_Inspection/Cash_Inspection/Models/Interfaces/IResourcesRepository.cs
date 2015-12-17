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
  public  interface IResourcesRepository
    {
        void TotalToCategoryTransaction(HttpContextBase http, Category category);
        void CategoryToSubTransactionAdd(HttpContextBase http, Category category, Subcategory subcategory);
        void CategoryToSubTransactionRemove(HttpContextBase http, Category category, Subcategory subcategory);
        void TotalToCategoryTransThowTheCat(HttpContextBase http, Category category, decimal res);
        void ImplUserResources(HttpContextBase http,UserLogEntry subC);
        IEnumerable<UserLogEntry> GetUserLog(HttpContextBase http);

    }
}
