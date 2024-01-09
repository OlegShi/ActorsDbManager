using ActorsManagerService.Models;
using Microsoft.EntityFrameworkCore;

namespace ActorsManagerService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Actor> ?Actors{ get; set; }
    }
}
