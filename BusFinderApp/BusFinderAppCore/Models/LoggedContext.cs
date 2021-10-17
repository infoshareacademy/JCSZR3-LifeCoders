using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusFinderAppWeb.Models
{

    public class User
    {
        public string Login { get; set; }
        public string password { get; set; }

    }

    
    public class LoggedContext : DbContext
    {
        public LoggedContext() :base()
        {
            
        }
       public virtual DbSet<User> users { get; set; }
    }
    
}
