
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Cash_Inspection.Models
{
    public interface IUnitOfWork : IDisposable
    {
        CategoryRepository Categories { get; }
        SubcategoryRepository Subcategories { get; }
        void Save();
    }
}
