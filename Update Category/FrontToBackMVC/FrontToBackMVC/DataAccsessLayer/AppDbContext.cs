using FrontToBackMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FrontToBackMVC.DataAccsessLayer
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        internal Task Where()
        {
            throw new NotImplementedException();
        }
    }
}
