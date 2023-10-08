

using BubberBreakFast.ServiceErrors;
using ErrorOr;

namespace BubberBreakFast.Services.Breakfast;

public class BreakfastServices: IBreakfastServices
{
    private static readonly Dictionary<Guid, Models.Breakfast> _breakfasts = new();

    public ErrorOr<Created> CreateBreakFast(Models.Breakfast breakfast)
    {
         _breakfasts.Add(breakfast.Id, breakfast);
         return Result.Created;
    }

    ErrorOr<Models.Breakfast> IBreakfastServices.GetBreakfast(Guid id){ 
        if(!_breakfasts.TryGetValue(id, out var breakfast))
        {
            return Errors.Breakfast.NotFound;
        }
        
        return _breakfasts[id];
    }


    public ErrorOr<Updated> UpdateBreakFast(Guid id, Models.Breakfast breakfast)
    {
        var isNewlyCreated = !_breakfasts.ContainsKey(breakfast.Id);
        _breakfasts[id] = breakfast;
        return Result.Updated;
    }

    ErrorOr<Deleted> IBreakfastServices.DeleteBreakFast(Guid id)
    {
        _breakfasts.Remove(id);
        return Result.Deleted;
    }

}

