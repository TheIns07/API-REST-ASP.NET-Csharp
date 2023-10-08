using Microsoft.AspNetCore.Mvc;

namespace BubberBreakFast.Controllers;

public class ErrorController : ControllerBase
{
    [HttpGet("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}