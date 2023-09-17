using SoftwareControle.API.Response;
using SoftwareControle.Models;

namespace SoftwareControle.API.Mapper;

public static class UsuarioModelToUsuarioResponse
{
    public static UsuarioResponse MapUsuarioModelToResponse(this UsuarioModel usuarioRequest)
    {
        return new UsuarioResponse()
        {
            Id = usuarioRequest.Id,
            Nome = usuarioRequest.Nome,
            Usuario = usuarioRequest.Usuario,
            Cargo = usuarioRequest.Cargo,
            DataCriacao = usuarioRequest.DataCriacao,
            DataAtualizacao = usuarioRequest.DataAtualizacao,
            Ordem = usuarioRequest.Ordem,
            Ferramenta = usuarioRequest.Ferramenta
        };
    }
}
