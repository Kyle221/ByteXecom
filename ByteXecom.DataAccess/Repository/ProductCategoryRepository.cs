using ByteXecom.DataAccess.Repository.IRepository;
using ByteXecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteXecom.DataAccess.Repository
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        private ByteXecomDbContext _db;

        public ProductCategoryRepository(ByteXecomDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductCategory productCategory)
        {
            _db.Update(productCategory);
        }
    }
}
