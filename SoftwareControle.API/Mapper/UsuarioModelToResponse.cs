﻿using SoftwareControle.API.Response;
using SoftwareControle.Models;

namespace SoftwareControle.API.Mapper;

public static class UsuarioModelToResponse
{
    public static UsuarioResponse MapUsuarioModelToResponse(this UsuarioModel usuarioRequest)
    {
        return new UsuarioResponse()
        {
            Id = usuarioRequest.Id,
            Nome = usuarioRequest.Nome,
            Cargo = usuarioRequest.Cargo,
            DataCriacao = usuarioRequest.DataCriacao,
            DataAtualizacao = usuarioRequest.DataAtualizacao,
            Ordem = usuarioRequest.Ordem,
            Ferramenta = usuarioRequest.Ferramenta
        };
    }
}
