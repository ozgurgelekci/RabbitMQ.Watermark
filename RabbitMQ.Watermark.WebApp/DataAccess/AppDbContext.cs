using Microsoft.EntityFrameworkCore;
using RabbitMQ.Watermark.WebApp.Models;

namespace RabbitMQ.Watermark.WebApp.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
