using SoftwareControle.Models;
using SoftwareControle.Repository.Repositorio.Usuario;

namespace HFAcademia.Services.Services.Usuario;

public class UsuarioService : IUsuarioService
{
	private readonly IUsuarioRepositorio _usuarioRepositorio;

	public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
	{
		_usuarioRepositorio = usuarioRepositorio;
	}

	public async Task<List<UsuarioModel>?> Buscar(CancellationToken cancellationToken)
	{
		return await _usuarioRepositorio.Buscar(cancellationToken);
	}

	public async Task<UsuarioModel?> Buscar(Guid id, CancellationToken cancellationToken)
	{
		return await _usuarioRepositorio.Buscar(id, cancellationToken);
	}

	public async Task<string?> Adicionar(UsuarioModel usuario, CancellationToken cancellationToken)
	{
		await _usuarioRepositorio.Adicionar(usuario, cancellationToken);

		return null;
	}

	public async Task<bool> Atualizar(UsuarioModel user, CancellationToken cancellationToken)
	{
		return await _usuarioRepositorio.Atualizar(user, cancellationToken);
	}
	public async Task<bool> Deletar(Guid id, CancellationToken cancellationToken)
	{
		return await _usuarioRepositorio.Deletar(id, cancellationToken);
	}
}
