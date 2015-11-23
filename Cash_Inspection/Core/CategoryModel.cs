using System.Collections.Generic;

namespace Core
{
    //Category
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal NumberofMoney { get; set; }

        public virtual ICollection<Subcategory> ListSubcategory { get; set; }
    }
    //Subcategory
    public class Subcategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Value { get; set; }

        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
