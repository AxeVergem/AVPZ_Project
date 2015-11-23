using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
namespace Cash_Inspection.Services.Interfaces
{
    //Category and Subcategory services
    public interface IOrder
    {
        void MakeOrderCategory(Category category);
        void MakeOrderSubcategory(Subcategory subcategory);
    }
}
