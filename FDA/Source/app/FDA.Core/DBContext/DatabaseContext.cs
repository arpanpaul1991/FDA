using FDA.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Core.DBContext
{
    public class DatabaseContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DatabaseContext()
            : base("FDA")
        {
        }


        public DbSet<Admin> Admin { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Establishment> Establishment { get; set; }
        public DbSet<EstablishmentStatus> EstablishmentStatus { get; set; }
        public DbSet<MenuList> MenuList { get; set; }
        public DbSet<MenuStatus> MenuStatus { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }
        public DbSet<OrderDetailHistory> OrderDetailHistory { get; set; }
    }


}
