using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Logging.Logger.DB
{
    internal class LogContext : DbContext
    {

        private readonly string _connectionString;

        public LogContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Log> Logs { get; set; }

        public DbSet<Parameter> Parameters { get; set; }

    }
}
