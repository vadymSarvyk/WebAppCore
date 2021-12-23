using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Core_MVS_Webapp.Models
{
    public class Good
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
