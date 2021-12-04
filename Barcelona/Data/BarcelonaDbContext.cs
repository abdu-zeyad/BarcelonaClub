using Barcelona.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Barcelona.Data
{
    public class BarcelonaDbContext : IdentityDbContext<ApplicationUser>
    {

       public DbSet<Player> Players { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Venue> Venues { get; set; }
       public BarcelonaDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
