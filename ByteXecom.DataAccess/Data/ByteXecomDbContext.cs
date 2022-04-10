using ByteXecom.Models;
using Microsoft.EntityFrameworkCore;

namespace ByteXecom.DataAccess
{
    public class ByteXecomDbContext : DbContext
    {
        public ByteXecomDbContext(DbContextOptions<ByteXecomDbContext> options) : base(options)
        {

        }
 
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
    }
}
