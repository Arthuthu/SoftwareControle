using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftwareControle.Models;

namespace SoftwareControle.Map;

public class OrdemMap : BaseMap<FerramentaModel>
{
	public OrdemMap() : base("Ordens")
	{
	}

	public override void Configure(EntityTypeBuilder<FerramentaModel> builder)
	{
		base.Configure(builder);

		builder.HasKey(x => x.Id);
	}
}
