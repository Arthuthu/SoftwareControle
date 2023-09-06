using SoftwareControle.Models;
using SoftwareControle.Repository.Repositorio.Ordem;

namespace HFAcademia.Services.Services.Usuario;

public class FerramentaService : IFerramentaService
{
	private readonly IFerramentaRepositorio _ferramentaRepositorio;

	public FerramentaService(IFerramentaRepositorio ferramentaRepositorio)
	{
		_ferramentaRepositorio = ferramentaRepositorio;
	}

	public async Task<List<FerramentaModel>?> Buscar(CancellationToken cancellationToken)
	{
		return await _ferramentaRepositorio.Buscar(cancellationToken);
	}

	public async Task<FerramentaModel?> Buscar(Guid id, CancellationToken cancellationToken)
	{
		return await _ferramentaRepositorio.Buscar(id, cancellationToken);
	}

	public async Task<string?> Adicionar(FerramentaModel ferramenta, CancellationToken cancellationToken)
	{
		await _ferramentaRepositorio.Adicionar(ferramenta, cancellationToken);

		return null;
	}

	public async Task<bool> Atualizar(FerramentaModel ferramenta, CancellationToken cancellationToken)
	{
		return await _ferramentaRepositorio.Atualizar(ferramenta, cancellationToken);
	}
	public async Task<bool> Deletar(Guid id, CancellationToken cancellationToken)
	{
		return await _ferramentaRepositorio.Deletar(id, cancellationToken);
	}
}
