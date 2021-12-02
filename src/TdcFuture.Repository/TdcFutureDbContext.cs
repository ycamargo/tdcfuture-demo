using Microsoft.EntityFrameworkCore;

namespace TdcFuture.Repository
{
    public class TdcFutureDbContext : DbContext
    {
        public TdcFutureDbContext() : base() { }

        public TdcFutureDbContext(DbContextOptions<TdcFutureDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
