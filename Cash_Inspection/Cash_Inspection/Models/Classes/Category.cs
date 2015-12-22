using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Inspection.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Название категории")]
      
        public string Title { get; set; }
        [Display(Name = "Лимит стредств")]          
        
        public decimal NumberofMoney { get; set; }

        public ICollection<Subcategory> ListSubcategory { get; set; }

        public  string iUserName { get; set; }
        public  ApplicationUser ApplicationUser { get; set; }
    }
    public class Subcategory
    {
        public int Id { get; set; }

        [Display(Name = "Содержание")]
        public string Title { get; set; }
        [Display(Name = "Стоимость")]          
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public  int CategoryId { get; set; }
        public  string UserId { get; set; }
        public  Category Category { get; set; }
    }
}
