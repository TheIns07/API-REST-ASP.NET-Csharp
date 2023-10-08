using BubberBreakfast.Contracts.Breakfast;
using BubberBreakFast.Models;
using BubberBreakFast.ServiceErrors;
using BubberBreakFast.Services.Breakfast;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BubberBreakFast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastsController: ApiController {

    public readonly IBreakfastServices _breakfastService;

    //Injection Dependencies
    public BreakfastsController(IBreakfastServices breakfastService){
        _breakfastService = breakfastService;
    }
    [HttpPost]
    public IActionResult CreateBreakFast(CreateBreakfastRequest req){

        ErrorOr<Breakfast> breakfastRequest = Breakfast.From(req);

        if(breakfastRequest.IsError){  
            return Problem(breakfastRequest.Errors);
        }

        var breakfast = breakfastRequest.Value;
        ErrorOr<Created> created = _breakfastService.CreateBreakFast(breakfast);

        if(created.IsError){
            return Problem(created.Errors);
        }

        return CreatedAtAction(nameof(GetBreakFast), 
                new {id = breakfast.Id}, 
                    value: MapBreakfastResponse(breakfast));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakFast(Guid id)
    {
        ErrorOr<Breakfast> breakfastResult = _breakfastService.GetBreakfast(id);

        return breakfastResult.Match(
            breakfast => Ok(MapBreakfastResponse(breakfast)),
                errors => Problem(errors));
    }

  
    [HttpPut("{id:guid}")]
    public IActionResult UpdateBreakFast(Guid id, UpdateBreakfastRequest req){
       ErrorOr<Breakfast> requestBreakfast = Breakfast.From(id, req);

        if(requestBreakfast.IsError){
            return Problem(requestBreakfast.Errors);
        }
 
        var breakfast = requestBreakfast.Value;
        ErrorOr<Updated> updated =_breakfastService.UpdateBreakFast(id, breakfast);

         return updated.Match(
            updated => Ok(MapBreakfastResponse(breakfast)),
            errors => Problem(errors)    
         );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakFast(Guid id){
        _breakfastService.DeleteBreakFast(id);
        return Ok(id);
    }


  private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
    {
        return new BreakfastResponse(
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
    }

     private CreatedAtActionResult CreatedAtGetBreakfast(Breakfast breakfast)
    {
        return CreatedAtAction(
            actionName: nameof(GetBreakFast),
            routeValues: new { id = breakfast.Id },
            value: MapBreakfastResponse(breakfast));
    }


}

