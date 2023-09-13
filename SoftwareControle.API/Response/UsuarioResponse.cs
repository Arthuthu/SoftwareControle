﻿namespace SoftwareControle.API.Response;

public class UsuarioResponse
{
    public Guid Id { get; set; }
    public string Usuario { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
}
