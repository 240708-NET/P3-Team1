namespace UniversityAPI.Services
{
    public class ServiceExceptions : Exception
    {
        public ServiceExceptions() : base() { }
        public ServiceExceptions(string message) : base(message) { }
    }

    public class StudentNotFoundException : ServiceExceptions
    {
        public StudentNotFoundException() : base() { }
        public StudentNotFoundException(string message) : base(message) { }
    }

    public class InvalidLoginException : ServiceExceptions
    {
        public InvalidLoginException() : base() { }
        public InvalidLoginException(string message) : base(message) { }
    }

    public class RegistrationFailedException : ServiceExceptions
    {
        public RegistrationFailedException() : base() { }
        public RegistrationFailedException(string message) : base(message) { }
    }

    public class SectionNotFoundException : ServiceExceptions
    {
        public SectionNotFoundException() : base() { }
        public SectionNotFoundException(string message) : base(message) { }
    }

    public class StudentAlreadyRegisteredException : ServiceExceptions
    {
        public StudentAlreadyRegisteredException() : base() { }
        public StudentAlreadyRegisteredException(string message) : base(message) { }
    }

    public class UpdateFailedException : ServiceExceptions
    {
        public UpdateFailedException() : base() { }
        public UpdateFailedException(string message) : base(message) { }
    }

    public class DeleteFailedException : ServiceExceptions
    {
        public DeleteFailedException() : base() { }
        public DeleteFailedException(string message) : base(message) { }
    }

    public class RepositoryException : ServiceExceptions
    {
        public RepositoryException() : base() { }
        public RepositoryException(string message) : base(message) { }
    }
}
