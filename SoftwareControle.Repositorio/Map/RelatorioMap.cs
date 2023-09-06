using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftwareControle.Models;

namespace HFAcademia.Map;

public class RelatorioMap : BaseMap<FerramentaModel>
{
	public RelatorioMap() : base("Relatorios")
	{
	}

	public override void Configure(EntityTypeBuilder<FerramentaModel> builder)
	{
		base.Configure(builder);

		builder.HasKey(x => x.Id);
	}
}
