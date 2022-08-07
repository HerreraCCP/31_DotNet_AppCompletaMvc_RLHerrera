using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RLHerrera.Business.Models;

namespace RLHerrera.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");
            
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnName("varchar(1000)");
            
            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnName("varchar(100)");

            builder.ToTable("Produtos");
        }
    }
}