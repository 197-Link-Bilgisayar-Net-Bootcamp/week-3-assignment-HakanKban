using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.Data.Models;

namespace Week3.Data.Abstract
{
    public  interface IProductRepository : IGenericRepository<Product>
    {
    }
}
