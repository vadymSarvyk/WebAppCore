using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ASP_Core_MVS_Webapp.Models
{
    public class ShopContext:DbContext
    {
        public DbSet<Good> Goods { get; set; }

        public DbSet<Category> Categories { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {
            Database.EnsureCreated();
        }


    }
}
