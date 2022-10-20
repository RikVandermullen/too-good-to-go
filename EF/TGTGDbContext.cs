using Microsoft.EntityFrameworkCore;

namespace TGTG_EF
{
    public class TGTGDbContext : DbContext
    {
        public DbSet<Canteen> Canteens { get; set; }
        public DbSet<Packet> Packets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public TGTGDbContext(DbContextOptions<TGTGDbContext> contextOptions) : base(contextOptions)
        {

        }
    }
}