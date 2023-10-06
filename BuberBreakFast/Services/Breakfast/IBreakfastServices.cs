namespace BubberBreakFast.Services.Breakfast;
using BubberBreakFast.Models;

public interface IBreakfastServices{

    void CreateBreakFast(Breakfast breakfast);
    Breakfast GetBreakfast(Guid id);
    void UpdateBreakFast(Guid id, Breakfast breakfast);
    void DeleteBreakFast(Guid id);

}