using SoftwareControle.Services.Services.Usuario;
using Microsoft.AspNetCore.Mvc;
using SoftwareControle.Models;

namespace SoftwareControle.API.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class OrdemController : ControllerBase
{
    private readonly IOrdemService _ordemService;

    public OrdemController(IOrdemService ordemService)
    {
        _ordemService = ordemService;
    }

    [HttpGet, Route("/orderm/buscar")]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var ordens = await _ordemService.Buscar(cancellationToken);

        if (ordens is null)
            return NotFound();

        return Ok(ordens);
    }

    [HttpGet, Route("/ordem/buscarporid/{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var orderm = await _ordemService.Buscar(id, cancellationToken);

        if (orderm is null)
            return NotFound();

        return Ok(orderm);
    }

    [HttpPost, Route("/orderm/criar")]
    public async Task<ActionResult<string?>> Post([FromForm] OrdemModel orderm,
        CancellationToken cancellationToken)
    {
        var resultado = await _ordemService.Adicionar(orderm, cancellationToken);

        if (resultado is not null)
            return BadRequest(resultado);

        return Ok(null);
    }

    [HttpPut, Route("/ordem/atualizar")]
    public async Task<IActionResult> Put([FromForm] OrdemModel ordem,
        CancellationToken cancellationToken)
    {
        bool ordemFoiAtualizada = await _ordemService.Atualizar(ordem,
            cancellationToken);

        if (ordemFoiAtualizada is false)
            return NotFound("Ordem não encontrada");

        return Ok(ordem);
    }

    [HttpDelete, Route("/ordem/deletar/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        bool ordemFoiDeletada = await _ordemService.Deletar(id, cancellationToken);

        if (ordemFoiDeletada is false)
            return NotFound("Ordem não encontrada");

        return Ok("Ordem deletada com sucesso");
    }
}
