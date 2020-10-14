using Microsoft.EntityFrameworkCore;

namespace SqliteTesting
{
    public class AppContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Film>().HasData(new Film {FilmId = 1, Name = "Testing", Genre = "HorrorMovie"});
        }
    }
}