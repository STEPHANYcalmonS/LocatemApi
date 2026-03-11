using Microsoft.EntityFrameworkCore;
using LocatemApi.Model;
namespace LocatemApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Defina os DbSet para suas entidades aqui
         public DbSet<Cliente> Cliente { get; set; }
         public DbSet<Endereco> Enderecos { get; set; }
    }
}
