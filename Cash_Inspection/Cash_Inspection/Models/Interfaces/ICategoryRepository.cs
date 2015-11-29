
using Cash_Inspection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Inspection.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll(System.Web.HttpContextBase httpcontext);
        IEnumerable<Subcategory> GetAllSubcategory(Category cat);
        Category Get(int id);
        void Create(Category item,System.Web.HttpContextBase httpcontext);
        void Update(Category item);
        void Delete(int id);
    }
}
