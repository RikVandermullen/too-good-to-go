using Microsoft.EntityFrameworkCore;
using System;

namespace TGTG_EF
{
    public class TGTGDbContext : DbContext
    {
        public DbSet<Canteen> Canteens { get; set; }
        public DbSet<Packet> Packets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PacketProduct> PacketProduct { get; set; }

        public TGTGDbContext(DbContextOptions<TGTGDbContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasIndex(p => new { p.Name })
                .IsUnique(true);

            modelBuilder.Entity<Packet>()
            .HasMany(x => x.Products)
            .WithMany(x => x.Packets)
            .UsingEntity<PacketProduct>(
                x => x.HasOne(pc => pc.Product).WithMany().HasForeignKey(pc => pc.ProductId),
                x => x.HasOne(pc => pc.Packet).WithMany().HasForeignKey(pc => pc.PacketId));

            base.OnModelCreating(modelBuilder);
        }
    }
}