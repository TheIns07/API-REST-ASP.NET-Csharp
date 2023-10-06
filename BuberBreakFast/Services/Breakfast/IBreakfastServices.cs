using BubberBreakfast.Contracts.Breakfast;

namespace BubberBreakFast.Services.Breakfast;

public interface IBreakfastService{
    BreakfastResponse CreateBreakfast(CreateBreakfastRequest request);
    BreakfastResponse GetBreakfast(Guid id);
    BreakfastResponse UpdateBreakfast(Guid id, UpdateBreakfastRequest request);
    BreakfastResponse DeleteBreakfast(Guid id);
}