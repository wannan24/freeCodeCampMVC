using FreeCC_MVC_web.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeCC_MVC_web.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<category> categories { get; set; }     
    }
}
