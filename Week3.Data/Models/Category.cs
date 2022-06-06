using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3.Data.Models
{
    public class Category
    {
        public int  Id { get; set; }
        public string CategoryName { get; set; }

        //Relationa Property
        public ICollection<Product> Products { get; set; }
    }
}
