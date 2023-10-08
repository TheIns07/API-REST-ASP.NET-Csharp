using BubberBreakfast.Contracts.Breakfast;
using BubberBreakFast.ServiceErrors;
using ErrorOr;

namespace BubberBreakFast.Models;

public class Breakfast {

    public const int MinDescriptionLength = 50;
    public const int MaxDescriptionLength = 150;
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;


    public Guid Id {get;}
    public string Name {get;}
    public string Description {get;}
    public DateTime StartDateTime {get; }
    public DateTime EndDateTime {get;}
    public DateTime LastModifiedDateTime {get;}
    public List<string> Savory {get;}
    public List<string> Sweet {get;}

    public Breakfast(Guid id, string name, string description, DateTime startTime, DateTime endTime, DateTime lastModifiedDateTime, List<string> savory, List<string> sweet){
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startTime;
        EndDateTime = endTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }   

    public static ErrorOr<Breakfast> 
    Create(string name, string description, DateTime startTime, DateTime lastModifiedDateTime, DateTime endTime, 
    List<string> savory, List<string> sweet, Guid? id = null)
    {

        List<Error> errors = new();

        if(name.Length is < MinNameLength or MaxNameLength){
            errors.Add(Errors.Breakfast.InvalidName);
        }   

         if(description.Length is < MinDescriptionLength or MaxDescriptionLength){
            errors.Add(Errors.Breakfast.InvalidDescription);
        } 

        if(errors.Count > 0)
        {
            return errors;
        }   
        
        
        return new Breakfast(
            id ?? Guid.NewGuid(),
            name,
            description,
            startTime,
            endTime,
            DateTime.UtcNow,
            savory,
            sweet
        );

    }

    public static ErrorOr<Breakfast>From(CreateBreakfastRequest request){
        return Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.Now,
            request.Savory,
            request.Sweet
        );
    }

    public static ErrorOr<Breakfast>From(Guid Id, UpdateBreakfastRequest request){
        return Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.Now,
            request.Savory,
            request.Sweet,
            Id
        );
    }

    

}