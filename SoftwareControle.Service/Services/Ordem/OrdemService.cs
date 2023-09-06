using SoftwareControle.Models;
using SoftwareControle.Repository.Repositorio.Ordem;

namespace SoftwareControle.Services.Services.Usuario;

public class OrdemService : IOrdemService
{
	private readonly IOrdemRepositorio _ordemRepositorio;

	public OrdemService(IOrdemRepositorio ordemRepositorio)
	{
		_ordemRepositorio = ordemRepositorio;
	}

	public async Task<List<OrdemModel>?> Buscar(CancellationToken cancellationToken)
	{
		return await _ordemRepositorio.Buscar(cancellationToken);
	}

	public async Task<OrdemModel?> Buscar(Guid id, CancellationToken cancellationToken)
	{
		return await _ordemRepositorio.Buscar(id, cancellationToken);
	}

	public async Task<string?> Adicionar(OrdemModel ordem, CancellationToken cancellationToken)
	{
		await _ordemRepositorio.Adicionar(ordem, cancellationToken);

		return null;
	}

	public async Task<bool> Atualizar(OrdemModel ordem, CancellationToken cancellationToken)
	{
		return await _ordemRepositorio.Atualizar(ordem, cancellationToken);
	}
	public async Task<bool> Deletar(Guid id, CancellationToken cancellationToken)
	{
		return await _ordemRepositorio.Deletar(id, cancellationToken);
	}
}
