using SoftwareControle.Repositório;
using SoftwareControle.Models;

namespace SoftwareControle.Services.Services.Usuario;

public class RelatorioService : IRelatorioService
{
	private readonly IRelatorioRepositorio _relatorioRepositorio;

	public RelatorioService(IRelatorioRepositorio relatorioRepositorio)
	{
		_relatorioRepositorio = relatorioRepositorio;
	}

	public async Task<List<RelatorioModel>?> Buscar(CancellationToken cancellationToken)
	{
		return await _relatorioRepositorio.Buscar(cancellationToken);
	}

	public async Task<RelatorioModel?> Buscar(Guid id, CancellationToken cancellationToken)
	{
		return await _relatorioRepositorio.Buscar(id, cancellationToken);
	}

	public async Task<string?> Adicionar(RelatorioModel relatorio, CancellationToken cancellationToken)
	{
		await _relatorioRepositorio.Adicionar(relatorio, cancellationToken);

		return null;
	}

	public async Task<bool> Atualizar(RelatorioModel relatorio, CancellationToken cancellationToken)
	{
		return await _relatorioRepositorio.Atualizar(relatorio, cancellationToken);
	}
	public async Task<bool> Deletar(Guid id, CancellationToken cancellationToken)
	{
		return await _relatorioRepositorio.Deletar(id, cancellationToken);
	}
}
