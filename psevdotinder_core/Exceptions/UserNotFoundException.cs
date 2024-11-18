namespace psevdotinder.Core.Exceptions;

public class UserNotFoundException(Guid wrongId) : Exception($"User {wrongId} is not found.") { }
