using ErrorOr;

namespace Domain.Common.Errors;

public static partial class Errors
{
    public static class Category
    {
        public static Error NullReference => Error.Unexpected(
            code: "Music.NullReference",
            description: "An unexpected error occurred. Attempting to access a null object, resulting in a NullReferenceException.");
    }
}
