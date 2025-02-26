using BlogBackASPNETCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogBackASPNETCore.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
