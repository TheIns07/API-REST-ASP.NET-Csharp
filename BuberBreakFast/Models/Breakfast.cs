namespace BubberBreakFast.Models;

public class Breakfast {
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

    

}