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

        public virtual ICollection<Subcategory> ListSubcategory { get; set; }

        public virtual string iUserName { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    public class Subcategory
    {
        public int Id { get; set; }

        [Display(Name = "Содержание")]
        public string Title { get; set; }

        [Display(Name = "Стоимость")]
        public decimal Value { get; set; }
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
