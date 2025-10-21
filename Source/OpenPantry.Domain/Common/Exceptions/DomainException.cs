using OpenPantry.Shared.Exceptions;

namespace OpenPantry.Domain.Common.Exceptions;

public abstract class DomainException(string message, Exception? innerException = null) : OpenPantryException(message, innerException);