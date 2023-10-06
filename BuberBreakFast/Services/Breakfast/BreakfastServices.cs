


namespace BubberBreakFast.Services.Breakfast;

public class BreakfastServices: IBreakfastServices
{
    private static readonly Dictionary<Guid, Models.Breakfast> _breakfasts = new();

    public void CreateBreakFast(Models.Breakfast breakfast)
    {
         _breakfasts.Add(breakfast.Id, breakfast);
    }

    public Models.Breakfast DeleteBreakFast(Guid id)
    {
        throw new NotImplementedException();
    }

    public Models.Breakfast GetBreakfast(Guid id){
        return _breakfasts[id];
    }


    public void UpdateBreakFast(Guid id, Models.Breakfast breakfast)
    {
        _breakfasts[id] = breakfast;
    }

    void IBreakfastServices.DeleteBreakFast(Guid id)
    {
        _breakfasts.Remove(id);
    }
}

