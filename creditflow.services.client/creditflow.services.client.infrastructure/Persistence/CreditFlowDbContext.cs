using creditflow.services.client.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace creditflow.services.client.infrastructure.Persistence
{
    public class CreditFlowDbContext : DbContext
    {
        public CreditFlowDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CreditFlowDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}