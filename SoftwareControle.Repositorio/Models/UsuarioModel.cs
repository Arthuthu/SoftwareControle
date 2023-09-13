namespace SoftwareControle.Models;

public class UsuarioModel
{
    public Guid Id { get; set; } 
	public string Usuario { get; set; } = string.Empty;
	public string Senha { get; set; } = string.Empty;
	public string Nome { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }

    // Propriedades de navegação
    public List<FerramentaModel>? Ferramenta { get; set; }
    public List<OrdemModel>? Ordem { get; set; }
}
