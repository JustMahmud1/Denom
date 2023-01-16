using Microsoft.EntityFrameworkCore;
using ProjectDenomHome.Models;

namespace ProjectDenomHome.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
    }
}
