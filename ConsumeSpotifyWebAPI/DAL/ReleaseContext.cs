using ConsumeSpotifyWebAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ConsumeSpotifyWebAPI.DAL
{
    public class ReleaseContext : DbContext
    {
        public ReleaseContext(DbContextOptions<ReleaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=SpotifyDatadb;Trusted_Connection=True;TrustServerCertificate=true;");

        }
        public DbSet<Release> Releases { get; set; }
    }
   
}