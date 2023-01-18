using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Infinite.MVC.Day1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("MyCon")
        {
          // Database.SetInitializer(new EComDBInitializer());
        }

        //Table Mapping
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Address> Addresses { get; set; }

        //For Authentication and Authorization
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRolesMapping> UserRolesMappings { get; set; }
    }

    public class EComDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //Add New Categories
            var categories = new List<Category>
            {
                new Category {CategoryName = "Mobile"},
                new Category {CategoryName = "Television"},
                new Category {CategoryName = "Clothing"},
                new Category {CategoryName = "Office"},
                new Category {CategoryName = "Electronics"},
            };
            categories.ForEach(x => context.Categories.Add(x));            

            //Add New Roles
            var roles = new List<Role>
            {
                new Role{RoleName="Admin"},
                new Role{RoleName="Customer"},
                new Role{RoleName="Executive"},
            };
            roles.ForEach(x => context.Roles.Add(x));

            context.SaveChanges();

            //base.Seed(context);
        }
    }
}