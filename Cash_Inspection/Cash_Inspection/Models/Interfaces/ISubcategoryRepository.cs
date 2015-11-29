
using Cash_Inspection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Inspection.Models
{
   public interface ISubcategoryRepository {

        IEnumerable<Subcategory> GetAll(System.Web.HttpContextBase http,Category cat);
        Subcategory Get(int id);
        void Create(Subcategory item, System.Web.HttpContextBase http);
        void Update(Subcategory item);
        void Delete(int id);
    }
}
