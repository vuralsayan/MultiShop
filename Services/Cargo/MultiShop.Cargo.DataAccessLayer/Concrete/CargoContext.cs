using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Concrete
{
    public class CargoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost, 1441;initial catalog=MultiShopCargoDb; User=test; Password=test");
        }

        public DbSet<CargoCompany>? CargoCompanies { get; set; }
        public DbSet<CargoCustomer>? CargoCustomers { get; set; }
        public DbSet<CargoDetail>? CargoDetails { get; set; }
        public DbSet<CargoOperation>? CargoOperations { get; set; }

    }
}
