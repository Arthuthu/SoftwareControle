using SoftwareControle.Models;

namespace HFAcademia.Services.Services.Usuario
{
	public interface IFerramentaService
	{
		Task<string?> Adicionar(FerramentaModel ferramenta, CancellationToken cancellationToken);
		Task<bool> Atualizar(FerramentaModel ferramenta, CancellationToken cancellationToken);
		Task<List<FerramentaModel>?> Buscar(CancellationToken cancellationToken);
		Task<FerramentaModel?> Buscar(Guid id, CancellationToken cancellationToken);
		Task<bool> Deletar(Guid id, CancellationToken cancellationToken);
	}
}