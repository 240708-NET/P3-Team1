using System.Diagnostics.CodeAnalysis;

namespace UniversityAPI.Services
{
    [ExcludeFromCodeCoverage]
    public class ServiceException : Exception
    {
        public ServiceException() : base() { }
        public ServiceException(string message) : base(message) { }
    }

    [ExcludeFromCodeCoverage]
    public class ResourceNotFoundException : ServiceException
    {
        public ResourceNotFoundException() : base() { }
        public ResourceNotFoundException(string message) : base(message) { }
    }

    [ExcludeFromCodeCoverage]
    public class ResourceCreationFailedException : ServiceException
    {
        public ResourceCreationFailedException() : base() { }
        public ResourceCreationFailedException(string message) : base(message) { }
    }

    [ExcludeFromCodeCoverage]
    public class ResourceUpdateFailedException : ServiceException
    {
        public ResourceUpdateFailedException() : base() { }
        public ResourceUpdateFailedException(string message) : base(message) { }
    }

    [ExcludeFromCodeCoverage]
    public class ResourceDeletionFailedException : ServiceException
    {
        public ResourceDeletionFailedException() : base() { }
        public ResourceDeletionFailedException(string message) : base(message) { }
    }

    [ExcludeFromCodeCoverage]
    public class StudentNotFoundException : ResourceNotFoundException
    {
        public StudentNotFoundException() : base() { }
        public StudentNotFoundException(string message) : base(message) { }
    }

    [ExcludeFromCodeCoverage]
    public class InvalidLoginException : ServiceException
    {
        public InvalidLoginException() : base() { }
        public InvalidLoginException(string message) : base(message) { }
    }

    [ExcludeFromCodeCoverage]
    public class RegistrationFailedException : ServiceException
    {
        public RegistrationFailedException() : base() { }
        public RegistrationFailedException(string message) : base(message) { }
    }

    [ExcludeFromCodeCoverage]
    public class SectionNotFoundException : ResourceNotFoundException
    {
        public SectionNotFoundException() : base() { }
        public SectionNotFoundException(string message) : base(message) { }
    }

    [ExcludeFromCodeCoverage]
    public class StudentAlreadyRegisteredException : ServiceException
    {
        public StudentAlreadyRegisteredException() : base() { }
        public StudentAlreadyRegisteredException(string message) : base(message) { }
    }

    [ExcludeFromCodeCoverage]
    public class RepositoryException : ServiceException
    {
        public RepositoryException() : base() { }
        public RepositoryException(string message) : base(message) { }
    }
}
