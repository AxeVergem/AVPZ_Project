using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Core;
namespace Cash_Inspection.Infrastructure.Data
{
    //Context
    public class DataContext : DbContext
    {
        public DataContext():base("DataContext") { }
        public DbSet<Category> DbCategory { get; set; }
        public DbSet<Subcategory> DbSubcategory { get; set; }
        static DataContext Create() { return new DataContext(); }
    }
}
