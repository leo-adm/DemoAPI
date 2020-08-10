using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Data
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
