using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Models.Home;

namespace WebApplication3.DataAccsessLayer
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AboutImg> AboutImgs { get; set; }

        public DbSet<AboutText> AboutTexts { get; set; }
        public DbSet<ExpertPerson> ExpertPersons { get; set; }
        public DbSet<ExpertTitle> ExpertTitle { get; set; }

        public DbSet<Background> Backgrounds { get; set; }
        public DbSet<BlogTitle> BlogTitles { get; set; }
        public DbSet<BlogContent> BlogContents { get; set; }
        public DbSet<PersonsAbout> PersonsAbouts { get; set; }
        public DbSet<SliderImgIcons> SliderImgIcons { get; set; }

        public DbSet<Product> products  { get; set; }
        public DbSet<Category> categories   { get; set; }

        public DbSet<Header> Headers { get; set; }
        public  DbSet<Footer> Footers { get; set; }

    }
}
