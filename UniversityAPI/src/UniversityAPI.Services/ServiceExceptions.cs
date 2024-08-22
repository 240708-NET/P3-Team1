namespace UniversityAPI.Services
{
    public class ServiceException : Exception
    {
        public ServiceException() : base() { }
        public ServiceException(string message) : base(message) { }
    }

    public class StudentNotFoundException : ServiceException
    {
        public StudentNotFoundException() : base() { }
        public StudentNotFoundException(string message) : base(message) { }
    }

    public class InvalidLoginException : ServiceException
    {
        public InvalidLoginException() : base() { }
        public InvalidLoginException(string message) : base(message) { }
    }

    public class RegistrationFailedException : ServiceException
    {
        public RegistrationFailedException() : base() { }
        public RegistrationFailedException(string message) : base(message) { }
    }

    public class SectionNotFoundException : ServiceException
    {
        public SectionNotFoundException() : base() { }
        public SectionNotFoundException(string message) : base(message) { }
    }

    public class StudentAlreadyRegisteredException : ServiceException
    {
        public StudentAlreadyRegisteredException() : base() { }
        public StudentAlreadyRegisteredException(string message) : base(message) { }
    }

    public class UpdateFailedException : ServiceException
    {
        public UpdateFailedException() : base() { }
        public UpdateFailedException(string message) : base(message) { }
    }

    public class DeleteFailedException : ServiceException
    {
        public DeleteFailedException() : base() { }
        public DeleteFailedException(string message) : base(message) { }
    }

    public class RepositoryException : ServiceException
    {
        public RepositoryException() : base() { }
        public RepositoryException(string message) : base(message) { }
    }
}
