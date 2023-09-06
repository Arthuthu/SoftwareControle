namespace SoftwareControle.Models;

public class UsuarioModel
{
    public Guid Id { get; set; } 
	public string Usuario { get; set; } = string.Empty;
	public string Senha { get; set; } = string.Empty;
	public string Nome { get; set; } = string.Empty;
	public bool IsAdministrador { get; set; }

    // Propriedades de navegação
    public List<OrdemModel>? Ordens { get; set; }
    public List<FerramentaModel>? Ferramentas { get; set; }
    public List<RelatorioModel>? Relatorios { get; set; }
}
