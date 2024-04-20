using Microsoft.EntityFrameworkCore;

namespace ScrappyStaris.DbContexts {
    public class SqliteContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Starship> Starships { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }
    }
}
