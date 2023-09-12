using SoftwareControle.Repositorio.Context;
using Microsoft.EntityFrameworkCore;
using SoftwareControle.Models;

namespace SoftwareControle.Repository.Repositorio.Ordem;

public class FerramentaRepositorio : IFerramentaRepositorio
{
	private readonly ApplicationDbContext _context;

	public FerramentaRepositorio(ApplicationDbContext context)
	{
		_context = context;
	}
	public async Task<List<FerramentaModel>?> Buscar(CancellationToken cancellationToken)
	{
		List<FerramentaModel>? ferramentas = await _context.Ferramentas.ToListAsync(cancellationToken);

		return ferramentas is not null ? ferramentas : null;
	}
	public async Task<FerramentaModel?> Buscar(Guid id, CancellationToken cancellationToken)
	{
		FerramentaModel? ferramenta = await _context.Ferramentas.SingleOrDefaultAsync
			(u => u.Id == id, cancellationToken);

		return ferramenta is not null ? ferramenta : null;
	}
	public async Task Adicionar(FerramentaModel ferramentas, CancellationToken cancellationToken)
	{
		await _context.Ferramentas.AddAsync(ferramentas, cancellationToken);
		await _context.SaveChangesAsync(cancellationToken);
	}
	public async Task<bool> Atualizar(FerramentaModel ferramentas, CancellationToken cancellationToken)
	{
		FerramentaModel? requestedFerramentas = await _context.Ferramentas.SingleOrDefaultAsync
			(u => u.Id == ferramentas.Id, cancellationToken);

		if (requestedFerramentas is null)
			return false;

		_context.Ferramentas.Update(requestedFerramentas);
		await _context.SaveChangesAsync(cancellationToken);

		return true;
	}
	public async Task<bool> Deletar(Guid id, CancellationToken cancellationToken)
	{
		int colunasAfetadas = await _context.Ferramentas.Where(u => u.Id == id)
									.ExecuteDeleteAsync(cancellationToken);

		await _context.SaveChangesAsync(cancellationToken);

		return colunasAfetadas > 0;
	}
}
