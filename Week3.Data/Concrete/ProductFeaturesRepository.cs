using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.Data.Abstract;
using Week3.Data.Context;
using Week3.Data.Models;

namespace Week3.Data.Concrete
{
    public class ProductFeaturesRepository : GenericRepository<ProductFeature>, IProductFeaturesRepository
    {
        public ProductFeaturesRepository(MyContext context) : base(context)
        {
        }
    }
}
