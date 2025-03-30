using MyWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
    }
}
