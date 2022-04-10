using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteXecom.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductCategoryRepository ProductCategory { get; }
        IProductBrandRepository ProductBrand { get; }

        void Save();
    }
}
