using Newtonsoft.Json;
using SoftwareControle.Models;
using System.Net.Http.Headers;

namespace SoftwareControle.Site.APICall.Ferramenta;

public class FerramentaEndpoints : IFerramentaEndpoints
{
    private readonly HttpClient _client;
    private readonly IConfiguration _config;
    private readonly ILogger<FerramentaEndpoints> _logger;

    public FerramentaEndpoints(HttpClient client,
    IConfiguration config,
    ILogger<FerramentaEndpoints> logger)
    {
        _client = client;
        _config = config;
        _logger = logger;
    }
    public async Task<List<FerramentaModel>?> Buscar()
    {
        string buscarTodosEndpoint = _config["apiLocation"] + _config["buscarFerramentas"];
        var authResult = await _client.GetAsync(buscarTodosEndpoint);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger
                .LogError("Ocorreu um erro durante o carregamento das ferramentas: {authContent}",
                authContent);

            return null;
        }

        var ferramentaModel = JsonConvert.DeserializeObject<List<FerramentaModel>>(authContent);

        return ferramentaModel;
    }
    public async Task<FerramentaModel?> BuscarPorId(Guid id)
    {
        string buscarPorIdEndpoint = _config["apiLocation"] + _config["buscarFerramentaPorId"] + $"/{id}";
        var authResult = await _client.GetAsync(buscarPorIdEndpoint);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger
                .LogError("Ocorreu um erro durante o carregamento da ferramenta por Id: {authContent}",
                authContent);

            return null;
        }

        var ferramentaModel = JsonConvert.DeserializeObject<FerramentaModel>(authContent);

        return ferramentaModel;
    }
    public async Task<string?> Criar(FerramentaModel ferramenta)
    {
        var content = new MultipartFormDataContent
        {
            { new StringContent(ferramenta.Nome), "Nome" },
            { new StringContent(ferramenta.Descricao), "Descricao" }
        };

        if (ferramenta.Imagem != null)
        {
            var imageContent = new ByteArrayContent(ferramenta.Imagem);
            imageContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            content.Add(imageContent, "Imagem", $"{ferramenta.Nome}.jpg"); 
        }

        content.Add(new StringContent(ferramenta.UsuarioId.ToString()), "UsuarioId");


        string criarUsuarioEndpoint = _config["apiLocation"] + _config["criarFerramenta"];
        var authResult = await _client.PostAsync(criarUsuarioEndpoint, content);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger
                .LogError("Ocorreu para registrar a ferramenta: {authContent}",
                authContent);

            return authContent;
        }

        return null;
    }

    public async Task<string?> Atualizar(FerramentaModel ferramenta)
    {
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("Id", ferramenta.Id.ToString()),
            new KeyValuePair<string, string>("Nome", ferramenta.Nome),
            new KeyValuePair<string, string>("Descricao", ferramenta.Descricao),
			new KeyValuePair<string, string>("Imagem", ferramenta.Imagem?.ToString() ?? "")
		});

        string atualizarEndpoint = _config["apiLocation"] + _config["atualizarFerramenta"];
        var authResult = await _client.PutAsync(atualizarEndpoint, data);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger
                .LogError("Ocorreu um erro ao atualizar a ferramenta: {authContent}",
                authContent);

            return null;
        }

        return await authResult.Content.ReadAsStringAsync();
    }
    public async Task<string?> Deletar(Guid id)
    {
        string deletarEndpoint = _config["apiLocation"] + _config["deletarFerramenta"] + $"/{id}";
        var authResult = await _client.DeleteAsync(deletarEndpoint);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger.LogError("Ocorreu um erro para deletar a ferramenta: {authContent}",
                authContent);

            return null;
        }

        return authContent;
    }
}
