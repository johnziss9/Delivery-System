using DeliverySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {} 

        public DbSet<Delivery> Deliveries { get; set; }
    }
}