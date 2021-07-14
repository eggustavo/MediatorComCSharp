using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EGG.Domain.Entities;

namespace EGG.Infra.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            builder.Navigation(p => p.Categoria).IsRequired();

            builder.ToTable("Produto");
        }
    }
}