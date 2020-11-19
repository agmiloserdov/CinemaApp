using Cinema.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data
{
    public class CinemaContext : IdentityDbContext<User>
    {
        public DbSet<Film> Films { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=cinema.db");
        
        public CinemaContext(DbContextOptions options) : base(options)
        {
        }
    }
}