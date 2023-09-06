using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftwareControle.Models;

namespace SoftwareControle.Map;

public class FerramentaMap : BaseMap<FerramentaModel>
{
	public FerramentaMap() : base("Ferramentas")
	{
	}

	public override void Configure(EntityTypeBuilder<FerramentaModel> builder)
	{
		base.Configure(builder);

		builder.HasKey(x => x.Id);
	}
}
