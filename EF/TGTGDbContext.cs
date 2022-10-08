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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IEnumerable<Canteen> canteens = new List<Canteen>
            {
                new Canteen { Id = 1, City = City.BREDA, Location = "HA", WarmMeals = true},
                new Canteen { Id = 2, City = City.BREDA, Location = "LD", WarmMeals = true},
                new Canteen { Id = 3, City = City.BREDA, Location = "LA", WarmMeals = false},
                new Canteen { Id = 4, City = City.TILBURG, Location = "CHL", WarmMeals = true},
                new Canteen { Id = 5, City = City.TILBURG, Location = "MD", WarmMeals = false},
                new Canteen { Id = 6, City = City.DENBOSCH, Location = "OWB215", WarmMeals = true},
                new Canteen { Id = 7, City = City.DENBOSCH, Location = "HP", WarmMeals = false},
            };

            IEnumerable<Employee> employees = new List<Employee>
            {
                new Employee { EmployeeNumber = 1, EmailAddress = "kantinemedewerker1@mail.com", Name = "Merel de Laat", Canteen = 3, Number = 1, Password = "Secret"}
            };

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Canteen>().HasData(canteens);
            modelBuilder.Entity<Canteen>().HasIndex(c => c.Id).IsUnique();

            modelBuilder.Entity<Employee>().HasData(employees);
            modelBuilder.Entity<Employee>().HasIndex(e => e.Number).IsUnique();

            modelBuilder.Entity<Packet>().HasMany(p => p.Products).WithMany(p => p.Packets).
                UsingEntity<PacketProduct>(
                j => j.HasOne(pp => pp.Product).WithMany(),
                j => j.HasOne(pp => pp.Packet).WithMany());
        }

    }
}