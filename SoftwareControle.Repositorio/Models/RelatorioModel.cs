namespace SoftwareControle.Models;

public class RelatorioModel
{
    public Guid Id { get; set; }
    public Guid FerramentaId { get; set; }
    public Guid OrdemId { get; set; }
    public Guid UsuarioId { get; set; }

    // Propriedades de navegação
    public FerramentaModel? Ferramenta { get; set; }
    public OrdemModel? CriarOrdem { get; set; }
    public UsuarioModel? Usuario { get; set; }
}
