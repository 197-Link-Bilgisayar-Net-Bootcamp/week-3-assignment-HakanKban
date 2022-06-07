﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.Data.Abstract;
using Week3.Data.Models;
using Week3.Service.Abstract;

namespace Week3.Service.Concrete
{
    public class ProductFeaturesService : GenericService<ProductFeature>, IProductFeaturesService
    {
        public ProductFeaturesService(IGenericRepository<ProductFeature> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
