using Microsoft.EntityFrameworkCore;


namespace Prøve.Repository.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        // Tables in DB.
        public DbSet<Hall> Hall { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Reserved> Reserved { get; set; }
    }
}
