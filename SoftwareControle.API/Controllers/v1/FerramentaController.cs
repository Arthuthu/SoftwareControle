using SoftwareControle.Services.Services.Usuario;
using Microsoft.AspNetCore.Mvc;
using SoftwareControle.Models;

namespace SoftwareControle.API.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class FerramentaController : ControllerBase
{
    private readonly IFerramentaService _ferramentaService;

    public FerramentaController(IFerramentaService ferramentaService)
    {
        _ferramentaService = ferramentaService;
    }

    [HttpGet, Route("/ferramenta/buscar")]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var ferramentas = await _ferramentaService.Buscar(cancellationToken);

        if (ferramentas is null)
            return NotFound();

        return Ok(ferramentas);
    }

    [HttpGet, Route("/ferramentas/buscarporid/{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var ferramenta = await _ferramentaService.Buscar(id, cancellationToken);

        if (ferramenta is null)
            return NotFound();

        return Ok(ferramenta);
    }

    [HttpPost, Route("/ferramenta/criar")]
    public async Task<ActionResult<string?>> Post([FromForm] FerramentaModel ferramenta,
        CancellationToken cancellationToken)
    {
        var resultado = await _ferramentaService.Adicionar(ferramenta, cancellationToken);

        if (resultado is not null)
            return BadRequest(resultado);

        return Ok(null);
    }

    [HttpPut, Route("/ferramenta/atualizar")]
    public async Task<IActionResult> Put([FromForm] FerramentaModel ferramenta,
        CancellationToken cancellationToken)
    {
        bool ferramentaFoiAtualizada = await _ferramentaService.Atualizar(ferramenta,
            cancellationToken);

        if (ferramentaFoiAtualizada is false)
            return NotFound("Ferramenta não encontrada");

        return Ok(ferramenta);
    }

    [HttpDelete, Route("/ferramenta/deletar/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        bool ferramentaFoiDeletada = await _ferramentaService.Deletar(id, cancellationToken);

        if (ferramentaFoiDeletada is false)
            return NotFound("Ferramenta não encontrada");

        return Ok("Ferramenta deletada com sucesso");
    }
}
