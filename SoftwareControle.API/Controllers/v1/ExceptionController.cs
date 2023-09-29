using Microsoft.AspNetCore.Mvc;

namespace SoftwareControle.API.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class ExceptionController : ControllerBase
{
    [HttpGet, Route("/exception/throw")]
    public IActionResult ThrowException()
    {
        throw new Exception("Exception thrown");
    }
}
