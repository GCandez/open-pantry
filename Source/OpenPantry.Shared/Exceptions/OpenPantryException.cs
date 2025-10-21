namespace OpenPantry.Shared.Exceptions;

public abstract class OpenPantryException(string message, Exception? innerException = null) : Exception(message, innerException);