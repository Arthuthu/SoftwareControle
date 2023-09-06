using SoftwareControle.Site.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;

namespace SoftwareControle.Site.APICall.Usuario;

public class UsuarioEndpoints : IUsuarioEndpoints
{
    private readonly HttpClient _client;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly NavigationManager _navigationManager;
    private readonly IConfiguration _config;
    private readonly ILogger<UsuarioEndpoints> _logger;

    public UsuarioEndpoints(HttpClient client,
    AuthenticationStateProvider authenticationStateProvider,
    NavigationManager navigationManager,
    IConfiguration config,
    ILogger<UsuarioEndpoints> logger)
    {
        _client = client;
        _authenticationStateProvider = authenticationStateProvider;
        _navigationManager = navigationManager;
        _config = config;
        _logger = logger;
    }
    public async Task<List<UsuarioModel>?> BuscarUsuarios()
    {
        string buscarTodosUsuariosEndpoint = _config["apiLocation"] + _config["bucarUsuarios"];
        var authResult = await _client.GetAsync(buscarTodosUsuariosEndpoint);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger
                .LogError("Ocorreu um erro durante o carregamento de usuarios: {authContent}",
                authContent);

            return null;
        }

        var userModel = JsonConvert.DeserializeObject<List<UsuarioModel>>(authContent);

        return userModel;
    }
    public async Task<UsuarioModel?> BuscarPorId(Guid id)
    {
        string buscarPorIdEndpoint = _config["apiLocation"] + _config["buscarPorId"] + $"/{id}";
        var authResult = await _client.GetAsync(buscarPorIdEndpoint);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger
                .LogError("Ocorreu um erro durante o carregamento do usuario por id: {authContent}",
                authContent);

            return null;
        }

        var userModel = JsonConvert.DeserializeObject<UsuarioModel>(authContent);

        return userModel;
    }
    public async Task<string?> Criar(UsuarioModel usuario)
    {
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("Id", usuario.Id.ToString()),
            new KeyValuePair<string, string>("Usuario", usuario.Usuario),
            new KeyValuePair<string, string>("Senha", usuario.Senha),
            new KeyValuePair<string, string>("Nome", usuario.Nome),
		});

        string criarUsuarioEndpoint = _config["apiLocation"] + _config["criarUsuario"];
        var authResult = await _client.PostAsync(criarUsuarioEndpoint, data);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger
                .LogError("Ocorreu para criar o usuario: {authContent}",
                authContent);

            return authContent;
        }

        return null;
    }

    public async Task<string?> AtualizarUsuario(UsuarioModel usuario)
    {
		var data = new FormUrlEncodedContent(new[]
		{
			new KeyValuePair<string, string>("Id", usuario.Id.ToString()),
			new KeyValuePair<string, string>("Usuario", usuario.Usuario),
			new KeyValuePair<string, string>("Senha", usuario.Senha),
			new KeyValuePair<string, string>("Nome", usuario.Nome),
		});

		string atualizarUsuarioEndpoint = _config["apiLocation"] + _config["atualizarUsuario"];
        var authResult = await _client.PutAsync(atualizarUsuarioEndpoint, data);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger
                .LogError("Ocorreu um erro ao atualizar o usuario: {authContent}",
                authContent);

            return null;
        }

        return await authResult.Content.ReadAsStringAsync();
    }
    public async Task<string?> DeletarUsuario(Guid id)
    {
        string deletarUsuarioEndpoint = _config["apiLocation"] + _config["deletarUsuario"] + $"/{id}";
        var authResult = await _client.DeleteAsync(deletarUsuarioEndpoint);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger.LogError("Ocorreu um erro para deletar o usuario: {authContent}",
                authContent);

            return null;
        }

        return authContent;
    }
}
