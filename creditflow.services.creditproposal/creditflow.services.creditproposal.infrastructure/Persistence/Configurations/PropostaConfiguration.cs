using creditflow.services.creditproposal.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace creditflow.services.creditproposal.infrastructure.Persistence.Configurations
{
    public class PropostaConfiguration : IEntityTypeConfiguration<Proposta>
    {
        public void Configure(EntityTypeBuilder<Proposta> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(p => p.Cliente).WithMany(c => c.Propostas).HasForeignKey(fk => fk.ClienteId);
        }
    }
}