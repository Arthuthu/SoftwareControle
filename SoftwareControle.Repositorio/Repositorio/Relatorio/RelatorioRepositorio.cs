using SoftwareControle.Repositorio.Context;
using Microsoft.EntityFrameworkCore;
using SoftwareControle.Models;

namespace SoftwareControle.Repositório;

public class RelatorioRepositorio : IRelatorioRepositorio
{
	private readonly ApplicationDbContext _context;
	public RelatorioRepositorio(ApplicationDbContext context)
	{
		_context = context;
	}
	public async Task<List<RelatorioModel>?> Buscar(CancellationToken cancellationToken)
	{
		List<RelatorioModel>? relatorios = await _context.Relatorios.ToListAsync(cancellationToken);

		return relatorios is not null ? relatorios : null;
	}
	public async Task<RelatorioModel?> Buscar(Guid id, CancellationToken cancellationToken)
	{
		RelatorioModel? relatorio = await _context.Relatorios.SingleOrDefaultAsync
			(u => u.Id == id, cancellationToken);

		return relatorio is not null ? relatorio : null;
	}
	public async Task Adicionar(RelatorioModel relatorio, CancellationToken cancellationToken)
	{
		await _context.Relatorios.AddAsync(relatorio, cancellationToken);
		await _context.SaveChangesAsync(cancellationToken);
	}
	public async Task<bool> Atualizar(RelatorioModel relatorio, CancellationToken cancellationToken)
	{
		RelatorioModel? requestedRelatorio = await _context.Relatorios.SingleOrDefaultAsync
			(u => u.Id == relatorio.Id, cancellationToken);

		if (requestedRelatorio is null)
			return false;

		_context.Relatorios.Update(requestedRelatorio);
		await _context.SaveChangesAsync(cancellationToken);

		return true;
	}
	public async Task<bool> Deletar(Guid id, CancellationToken cancellationToken)
	{
		int colunasAfetadas = await _context.Relatorios.Where(u => u.Id == id)
									.ExecuteDeleteAsync(cancellationToken);

		await _context.SaveChangesAsync(cancellationToken);

		return colunasAfetadas > 0;
	}
}
