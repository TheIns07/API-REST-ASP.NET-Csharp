using BubberBreakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;
namespace BubberBreakFast.Controllers;

[ApiController]
[Route("[breakfasts]")]
public class BreakfastsController: ControllerBase {

    [HttpPost("/")]
    public IActionResult CreateBreakFast(CreateBreakfastRequest req){
        return Ok(req);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakFast(Guid id){
        return Ok(id);
    }

    [HttpGet("{id:guid}")]
    public IActionResult UpdateBreakFast(Guid id, UpdateBreakfastRequest req){
        return Ok(req);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakFast(Guid id){
        return Ok(id);
    }




}

