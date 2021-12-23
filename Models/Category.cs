using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ASP_Core_MVS_Webapp.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name ="Название категории")]

        public string Title { get; set; }

        public List<Good> Goods { get; set; }

    }
}
