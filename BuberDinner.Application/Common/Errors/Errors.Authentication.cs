namespace BuberDinner.Application.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Unauthorized(
            "Auth.InvalidCred",
            "Invalid credentials."
        );
    }
}