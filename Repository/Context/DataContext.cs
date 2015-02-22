using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DbContext;
using Infrastructure.Models;

namespace Repository.Context
{
    public class DataContext : DbContext ,IContext
    {
        public DataContext() : base("SuppliersDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>("SuppliersDb"));

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }

        public IDbSet<Users> Users { get; set; }
        public IDbSet<Products> Products { get; set; }
        public IDbSet<Category> Category { get; set; }
        public IDbSet<Suppliers> Suppliers { get; set; }
        public IDbSet<Employees> Employees { get; set; }
        public IDbSet<Roles> Roles { get; set; }

       
    }
}
