﻿using ByteXecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteXecom.DataAccess.Repository.IRepository
{
    public interface IProductBrandRepository : IRepository<ProductBrand>
    {
        void Update(ProductBrand productBrand);
        
    }
}
