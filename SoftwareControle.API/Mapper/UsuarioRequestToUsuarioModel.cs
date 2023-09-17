using SoftwareControle.API.Requests;
using SoftwareControle.Models;

namespace SoftwareControle.API.Mapper;

public static class UsuarioRequestToUsuarioModel
{
	public static UsuarioModel MapUsuarioRequestToUsuarioModel(this UsuarioRequest usuarioRequest)
	{
		return new UsuarioModel
		{
			Id = usuarioRequest.Id,
			Usuario = usuarioRequest.Usuario,
			Senha = usuarioRequest.Senha,
			Nome = usuarioRequest.Nome,
			Cargo = usuarioRequest.Cargo
		};
	}
}
