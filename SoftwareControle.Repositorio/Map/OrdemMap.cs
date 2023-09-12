using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftwareControle.Models;

namespace SoftwareControle.Map;

public class OrdemMap : BaseMap<OrdemModel>
{
	public OrdemMap() : base("Ordens")
	{
	}

	public override void Configure(EntityTypeBuilder<OrdemModel> builder)
	{
		base.Configure(builder);

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000).HasColumnName("Descricao");
		builder.Property(x => x.NivelUrgencia).HasMaxLength(50).HasColumnName("NivelUrgencia");
		builder.Property(x => x.Situacao).HasMaxLength(50).HasColumnName("Situacao");
		builder.Property(x => x.DataCricao).HasMaxLength(50).HasColumnName("DataCriacao");
		builder.Property(x => x.UsuarioId).HasMaxLength(50).HasColumnName("UsuarioId");
		builder.Property(x => x.FerramentaId).HasMaxLength(50).HasColumnName("FerramentaId");

        builder.HasOne(x => x.Ferramenta).WithMany(x => x.Ordem)
			.HasForeignKey(x => x.FerramentaId);

        builder.HasOne(x => x.Usuario).WithMany(x => x.Ordem)
            .HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.NoAction);
    }
}
