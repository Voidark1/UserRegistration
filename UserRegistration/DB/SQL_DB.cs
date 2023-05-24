using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration.DB
{
    internal class SQL_DB : DbContext
    {
        string cs = "Server=192.168.49.180;" + "Database=User_Registration_24_05; user id=stud; password=stud;" + "TrustServerCertificate=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cs);
        }
        public DbSet<User> Users { get; set; }
    }
}
