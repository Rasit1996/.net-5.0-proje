using BlogCoreApi.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogCoreApi.DataAccessLayer.Content
{
    public class ApiContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-LAHHDS9;database=CoreDemoApiBlock;integrated security=true;");
        }

        public DbSet<personel>  personels { get; set; }
    }
}
