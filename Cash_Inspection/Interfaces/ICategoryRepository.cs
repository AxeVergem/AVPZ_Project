using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
namespace Interfaces
{
    //Category
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategoryList();
        Category GetCategory(int id);
        void Create(Category item);
        void Update(Category item);
        void Delete(int id);
        void Save();
    }
}
