using creditflow.services.creditproposal.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace creditflow.services.creditproposal.infrastructure.Persistence
{
    public class CreditFlowDbContext : DbContext
    {
        public CreditFlowDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Proposta> Propostas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CreditFlowDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}