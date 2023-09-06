using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftwareControle.Models;

namespace HFAcademia.Map;

public class UsuarioMap : BaseMap<FerramentaModel>
{
	public UsuarioMap() : base("Usuarios")
	{
	}

	public override void Configure(EntityTypeBuilder<FerramentaModel> builder)
	{
		base.Configure(builder);

		builder.HasKey(x => x.Id);
	}
}
