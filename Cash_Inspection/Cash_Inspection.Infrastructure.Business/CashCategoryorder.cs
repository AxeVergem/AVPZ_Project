using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cash_Inspection.Services.Interfaces;
using Core;
namespace Cash_Inspection.Infrastructure.Business
{
    //Order
    public class CacheCategoryOrder : IOrder
    {
        public void MakeOrderCategory(Category category)
        {
            // код категорий
        }
        public void MakeOrderSubcategory(Subcategory subcategory)
        {
            // код для подкатегорий
        }
    }
}
