using SoftwareControle.Services.Services.Usuario;
using Microsoft.AspNetCore.Mvc;
using SoftwareControle.Models;
using Microsoft.AspNetCore.Authorization;
using SoftwareControle.API.Response;
using SoftwareControle.API.Mapper;
using SoftwareControle.API.Requests;

namespace SoftwareControle.API.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet, Route("/usuario/buscar"), Authorize]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var usuarios = await _usuarioService.Buscar(cancellationToken);

        List<UsuarioResponse> usuariosResponse = new();

        if (usuarios is null)
            return NotFound();

        foreach (var usuario in usuarios)
        {
            var usuarioResponse = usuario.MapUsuarioModelToResponse();
            usuariosResponse.Add(usuarioResponse);
        }

        return Ok(usuariosResponse);
    }

    [HttpGet, Route("/usuario/buscarporid/{id:guid}"), Authorize]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioService.Buscar(id, cancellationToken);

        if (usuario is null)
            return NotFound();

        UsuarioResponse? usuarioResponse = usuario.MapUsuarioModelToResponse();

        return Ok(usuarioResponse);
    }

    [HttpPost, Route("/usuario/criar"), Authorize]
    public async Task<ActionResult<string?>> Post([FromForm] UsuarioRequest usuarioRequest,
        CancellationToken cancellationToken)
    {
        var resultado = await _usuarioService.Adicionar(usuarioRequest.MapUsuarioRequestToUsuarioModel(),
            cancellationToken);

        if (resultado is not null)
            return BadRequest(resultado);

        return Ok(null);
    }

    [HttpPut, Route("/usuario/atualizar"), Authorize]
    public async Task<IActionResult> Put([FromForm] UsuarioModel usuario,
        CancellationToken cancellationToken)
    {
        bool usuarioFoiAtualizado = await _usuarioService.Atualizar(usuario,
            cancellationToken);

        if (usuarioFoiAtualizado is false)
            return NotFound("Usuario não encontrado");

        return Ok(usuario);
    }

    [HttpDelete, Route("/usuario/deletar/{id:guid}"), Authorize]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        bool usuarioFoiDeletado = await _usuarioService.Deletar(id, cancellationToken);

        if (usuarioFoiDeletado is false)
            return NotFound("Usuario não encontrado");

        return Ok("Usuario deletado com sucesso");
    }
}
