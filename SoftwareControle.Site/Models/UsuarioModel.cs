﻿namespace SoftwareControle.Site.Models;

public class UsuarioModel
{
	public Guid Id { get; set; }
	public string Usuario { get; set; } = string.Empty;
	public string Senha { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
	public string Cargo = string.Empty;
	public DateTime DataCriacao { get; set; }
}
