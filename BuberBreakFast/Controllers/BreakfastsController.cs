using BubberBreakfast.Contracts.Breakfast;
using BubberBreakFast.Models;
using Microsoft.AspNetCore.Mvc;

namespace BubberBreakFast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastsController: ControllerBase {

    [HttpPost]
    public IActionResult CreateBreakFast(CreateBreakfastRequest req){
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            req.Name,
            req.Description,
            req.StartDateTime,
            req.EndDateTime,
            DateTime.UtcNow,
            req.Savory,
            req.Sweet
        );

        var response = new BreakfastResponse( 
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet,
            DateTime.UtcNow 
        );

        return CreatedAtAction(nameof(GetBreakFast), new {id = breakfast.Id}, breakfast);
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

