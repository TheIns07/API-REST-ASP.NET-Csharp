using ErrorOr;

namespace BubberBreakFast.ServiceErrors;


public static class Errors {
    public static class Breakfast {

        public static Error NotFound => Error.NotFound(
            code: "Breakfast not found",
            description: "Breakfast with given id does not exist"
        );
    }
}