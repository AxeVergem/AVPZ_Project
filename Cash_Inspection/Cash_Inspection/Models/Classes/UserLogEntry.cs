using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Inspection.Models
{
   public class UserLogEntry
    {
        public int Id { get; set; }  
        [Display(Name = "Средства")]
       
        [Range(0,UInt32.MaxValue)]
        public decimal Value { get; set; }
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
        public DateTime Date { get; set; }      
        public string UserId { get; set; } 
        public ApplicationUser ApplicationUser { get; set; }
       
    }
}
