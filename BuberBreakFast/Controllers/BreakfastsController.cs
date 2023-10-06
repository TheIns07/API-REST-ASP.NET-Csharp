using BubberBreakfast.Contracts.Breakfast;
using BubberBreakFast.Models;
using BubberBreakFast.Services.Breakfast;
using Microsoft.AspNetCore.Mvc;

namespace BubberBreakFast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastsController: ControllerBase {

    public readonly IBreakfastServices _breakfastService;

    //Injection Dependencies
    public BreakfastsController(IBreakfastServices breakfastService){
        _breakfastService = breakfastService;
    }
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

        _breakfastService.CreateBreakFast(breakfast);

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
        Breakfast breakfast = _breakfastService.GetBreakfast(id);
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
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateBreakFast(Guid id, UpdateBreakfastRequest req){
        var breakfast = new Breakfast(
            id,
            req.Name,
            req.Description,
            req.StartDateTime,
            req.EndDateTime,    
            DateTime.UtcNow,    
            req.Savory, 
            req.Sweet       
        );
        _breakfastService.UpdateBreakFast(id, breakfast);
        //Return 201 if created
        return Ok(breakfast); 
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakFast(Guid id){
        _breakfastService.DeleteBreakFast(id);
        return Ok(id);
    }




}

