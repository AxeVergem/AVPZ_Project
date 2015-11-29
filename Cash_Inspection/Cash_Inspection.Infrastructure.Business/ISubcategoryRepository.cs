using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
namespace Interfaces
{
    //Subcategory
    public interface ISubcategoryRepository : IDisposable
    {
        IEnumerable<Subcategory> GetSubcategoryList();
        Subcategory GetSubcategory(int id);
        void Create(Subcategory item);
        void Update(Subcategory item);
        void Delete(int id);
        void Save();
    }
}
