using ByteXecom.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteXecom.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ByteXecomDbContext _db;

        public UnitOfWork(ByteXecomDbContext db)
        {
            _db = db;
            ProductCategory = new ProductCategoryRepository(_db);
            ProductBrand = new ProductBrandRepository(_db);
        }

        public IProductCategoryRepository ProductCategory { get; private set; }
        public IProductBrandRepository ProductBrand { get; private set; }
       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
