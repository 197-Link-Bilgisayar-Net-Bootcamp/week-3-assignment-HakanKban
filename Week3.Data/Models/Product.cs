using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal  Price { get; set; }
        //Relational Property
        public int CategoryId { get; set; }
        //Navigation Property-- One to many
        public Category Category { get; set; }

        //Navigation Property -- One to One
        public ProductFeature ProductFeature { get; set; }
    }
}
