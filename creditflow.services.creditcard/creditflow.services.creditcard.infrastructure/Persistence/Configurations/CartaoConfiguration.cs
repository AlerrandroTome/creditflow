using creditflow.services.creditcard.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace creditflow.services.creditcard.infrastructure.Persistence.Configurations
{
    public class CartaoConfiguration : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(p => p.Cliente).WithMany(c => c.Cartoes).HasForeignKey(fk => fk.ClienteId);
        }
    }
}