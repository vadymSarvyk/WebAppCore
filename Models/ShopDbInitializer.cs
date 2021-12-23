using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Core_MVS_Webapp.Models
{
    public class ShopDbInitializer
    {
        public static void Initialize(ShopContext context)
        {
            if(!context.Categories.Any())
            {
                context.Categories.AddRange(new Category { Title = "Телефоны" }, new Category { Title = "Бытовая техника" });
                context.SaveChanges();
            }
        }
    }
}
