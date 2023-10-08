using BubberBreakfast.Contracts.Breakfast;
using BubberBreakFast.Models;
using BubberBreakFast.ServiceErrors;
using BubberBreakFast.Services.Breakfast;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BubberBreakFast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastsController : ApiController
{

    public readonly IBreakfastServices _breakfastService;

    //Injection Dependencies
    public BreakfastsController(IBreakfastServices breakfastService)
    {
        _breakfastService = breakfastService;
    }
    [HttpPost]
    public IActionResult CreateBreakFast(CreateBreakfastRequest req)
    {
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

        ErrorOr<Created> created = _breakfastService.CreateBreakFast(breakfast);

        return created.Match(
            created => CratedAsABreakFast(breakfast),
            error => Problem(error));
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
    public IActionResult UpdateBreakFast(Guid id, UpdateBreakfastRequest req)
    {
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
        ErrorOr<UpdatedBreakfast> updatedbreakfast = _breakfastService.UpdateBreakFast(id, breakfast);
        if (updatedbreakfast.IsError)
        {
            return Problem(updatedbreakfast.Errors);
        }
        //Return 201 if created
        return updatedbreakfast.Match(
            upserted => upserted.isNewly ? 
                (CratedAsABreakFast(breakfast)): 
                    NoContent(),
            error => Problem(error));
    }

    

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakFast(Guid id)
    {
        ErrorOr<Deleted> deleted = _breakfastService.DeleteBreakFast(id);
        return deleted.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private CreatedAtActionResult CratedAsABreakFast(Breakfast breakfast)
    {
        return CreatedAtAction(
                    actionName: nameof(GetBreakFast),
                    routeValues: new { id = breakfast.Id },
                    value: MapBreakfastResponse(breakfast)
                );
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


}

