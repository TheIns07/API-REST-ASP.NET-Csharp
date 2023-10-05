using BubberBreakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;
namespace BubberBreakFast.Controllers;

[ApiController]
public class BreakfastsController: ControllerBase {

    [HttpPost("/breakfasts")]
    public IActionResult CreateBreakFast(CreateBreakfastRequest req){
        return Ok(req);
    }

    [HttpGet("/breakfasts/{id:guid}")]
    public IActionResult GetBreakFast(Guid id){
        return Ok(id);
    }




}

