using ErrorOr;

namespace NetCleanArchitecture.Domain;

public static partial class Errors
{
    public static class TaskList
    {
        public static Error NotFound => Error.NotFound(
            code: "TaskList.NotFound",
            description: "The requested task list could not be found. Please verify the task list Id and try again.");

        public static Error NameEmpty => Error.Validation(
            code: "TaskList.NameEmpty",
            description: "TaskList name cannot be empty or whitespace.");

        public static Error NameTooLong => Error.Validation(
            code: "TaskList.NameTooLong",
            description: "TaskList name cannot exceed 100 characters.");
    }
}
