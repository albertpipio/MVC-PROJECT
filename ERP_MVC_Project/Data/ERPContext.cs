using ERP_MVC_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_MVC_Project.Data
{
    public class ERPContext : DbContext
    {
        public ERPContext(DbContextOptions<ERPContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
