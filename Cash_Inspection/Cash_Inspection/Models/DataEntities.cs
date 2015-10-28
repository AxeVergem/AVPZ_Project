using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Cash_Inspection.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Cash_Inspection.Model
{
    public class DataEntities : DbContext
    {

        public DataEntities() : base("DataEntities") { }
        public virtual DbSet<Category> CategoryDb { get; set; }
        public virtual DbSet<Subcategory> SubcategoryDb { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
