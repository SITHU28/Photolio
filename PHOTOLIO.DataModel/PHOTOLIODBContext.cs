using PHOTOLIO.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PHOTOLIO.DataModel
{
    public class PHOTOLIODBContext : DbContext
    {
        public PHOTOLIODBContext(): base("Myconnection")
        {
            Database.SetInitializer<PHOTOLIODBContext>(null);
        }
       
        public DbSet<ProductDM> ProductDMs { get; set; }
        public DbSet<CategoryDM> CategoryDMs { get; set; }
        public DbSet<PositionDM> PositionDMs { get; set; }
        public DbSet<ContactUsDM> ContactUsDMs { get; set; }
        public DbSet<UserDM> UserDMs { get; set; }
        public DbSet<OrderDM> OrderDMs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContactUsDM>().ToTable("ContactUs");
            modelBuilder.Entity<CategoryDM>().ToTable("Category");
            modelBuilder.Entity<PositionDM>().ToTable("Position");
            modelBuilder.Entity<ProductDM>().ToTable("Product");
            modelBuilder.Entity<OrderDM>().ToTable("Order");
            modelBuilder.Entity<UserDM>().ToTable("User");
        }
    }
}
