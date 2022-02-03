using FirstHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstHomework.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Type> Types { get; set; }
        public object Catagories { get;  set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }


    }
}
