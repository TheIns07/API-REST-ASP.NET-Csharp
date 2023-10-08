namespace BubberBreakFast.Services.Breakfast;
using BubberBreakFast.Models;
using ErrorOr;

public interface IBreakfastServices{

    ErrorOr<Created> CreateBreakFast(Breakfast breakfast);
    ErrorOr<Breakfast> GetBreakfast(Guid id);
    ErrorOr<Updated> UpdateBreakFast(Guid id, Breakfast breakfast);
    ErrorOr<Deleted> DeleteBreakFast(Guid id);

}