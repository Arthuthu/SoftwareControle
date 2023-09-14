using SoftwareControle.Services.Services.Usuario;
using Microsoft.AspNetCore.Mvc;
using SoftwareControle.Models;
using Microsoft.AspNetCore.Authorization;

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

        if (usuarios is null)
            return NotFound();

        return Ok(usuarios);
    }

    [HttpGet, Route("/usuario/buscarporid/{id:guid}"), Authorize]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioService.Buscar(id, cancellationToken);

        if (usuario is null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost, Route("/usuario/criar"), Authorize]
    public async Task<ActionResult<string?>> Post([FromForm] UsuarioModel usuario,
        CancellationToken cancellationToken)
    {
        var resultado = await _usuarioService.Adicionar(usuario, cancellationToken);

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
