using creditflow.services.client.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace creditflow.services.client.infrastructure.Persistence.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Propostas).WithOne().HasForeignKey(c => c.ClienteId);
            builder.HasMany(c => c.Cartoes).WithOne().HasForeignKey(c => c.ClienteId);
        }
    }
}
