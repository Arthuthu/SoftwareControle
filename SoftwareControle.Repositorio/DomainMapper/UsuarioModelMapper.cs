using SoftwareControle.Models;

namespace SoftwareControle.Repositorio.DomainMapper;

public static class UsuarioModelMapper
{
    public static UsuarioModel MapUsuarioModel(this UsuarioModel usuarioModel)
    {
        return new UsuarioModel() 
        {
            Id = usuarioModel.Id,
            Usuario = usuarioModel.Usuario,
            Senha = usuarioModel.Senha,
            Nome = usuarioModel.Nome,
            Cargo = usuarioModel.Cargo,
            DataCriacao = usuarioModel.DataCriacao,
            DataAtualizacao = usuarioModel.DataAtualizacao,
            Ordem = usuarioModel.Ordem,
            Ferramenta = usuarioModel.Ferramenta
        };

    }
}
