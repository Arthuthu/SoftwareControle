using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftwareControle.Map;
using SoftwareControle.Models;

namespace SoftwareControle.Repositorio.Map;

public class RelatorioMap : BaseMap<RelatorioModel>
{
    public RelatorioMap() : base("Relatorios")
    {

    }
    public override void Configure(EntityTypeBuilder<RelatorioModel> builder)
    {
        base.Configure(builder);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Descricao).IsRequired().HasColumnName("Descricao")
            .HasMaxLength(3000);
        builder.Property(x => x.FerramentaNome).HasColumnName("FerramentaNome")
            .HasMaxLength(64);
        builder.Property(x => x.UsuarioNome).HasColumnName("UsuarioNome")
            .HasMaxLength(64);
        builder.Property(x => x.FerramentaId).HasColumnName("FerramentaId");
        builder.Property(x => x.UsuarioId).HasColumnName("UsuarioId");
        builder.Property(x => x.OrdemId).HasColumnName("OrdemId");
        builder.Property(x => x.DataCriacao).HasColumnName("DataCriacao");
    } 
}