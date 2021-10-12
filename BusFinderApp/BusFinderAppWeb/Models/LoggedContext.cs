using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusFinderAppWeb.Models
{

    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string password { get; set; }

    }

    
    public class LoggedContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=busfinder;Integrated Security=True;Connect Timeout=30;");
        }
       
       public virtual DbSet<User> users { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   Login = "William",
                   password = "123"
               },
               new User
               {
                   Id = 2,
                   Login = "admin",
                   password = "admin"
               }

           );
       }
    }
    
}
