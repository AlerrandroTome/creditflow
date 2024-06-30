using creditflow.services.creditcard.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace creditflow.services.creditcard.infrastructure.Persistence
{
    public class CreditFlowDbContext : DbContext
    {
        public CreditFlowDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cartao> Cartoes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CreditFlowDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}