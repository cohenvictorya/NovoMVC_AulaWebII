using Microsoft.EntityFrameworkCore;
using NovoMVC.Models;

namespace NovoMVC.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
    }
}
