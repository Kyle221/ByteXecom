using ByteXecom.DataAccess.Repository.IRepository;
using ByteXecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteXecom.DataAccess.Repository
{
    public class ProductBrandRepository : Repository<ProductBrand>, IProductBrandRepository
    {
        private ByteXecomDbContext _db;

        public ProductBrandRepository(ByteXecomDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductBrand productBrand)
        {
            _db.Update(productBrand);
        }
    }
}
