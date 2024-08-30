using System.Diagnostics.CodeAnalysis;

namespace UniversityAPI.Services
{
    /// <summary>
    /// Represents the base class for all service-related exceptions in the application.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ServiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class.
        /// </summary>
        public ServiceException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ServiceException(string message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when a requested resource is not found.
    /// Inherits from <see cref="ServiceException"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ResourceNotFoundException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceNotFoundException"/> class.
        /// </summary>
        public ResourceNotFoundException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceNotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ResourceNotFoundException(string message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when the creation of a resource fails.
    /// Inherits from <see cref="ServiceException"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ResourceCreationFailedException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceCreationFailedException"/> class.
        /// </summary>
        public ResourceCreationFailedException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceCreationFailedException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ResourceCreationFailedException(string message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when the update of a resource fails.
    /// Inherits from <see cref="ServiceException"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ResourceUpdateFailedException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceUpdateFailedException"/> class.
        /// </summary>
        public ResourceUpdateFailedException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceUpdateFailedException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ResourceUpdateFailedException(string message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when the deletion of a resource fails.
    /// Inherits from <see cref="ServiceException"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ResourceDeletionFailedException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceDeletionFailedException"/> class.
        /// </summary>
        public ResourceDeletionFailedException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceDeletionFailedException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ResourceDeletionFailedException(string message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when a student is not found.
    /// Inherits from <see cref="ResourceNotFoundException"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentNotFoundException : ResourceNotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentNotFoundException"/> class.
        /// </summary>
        public StudentNotFoundException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentNotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public StudentNotFoundException(string message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when a student's login attempt is invalid.
    /// Inherits from <see cref="ServiceException"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class InvalidLoginException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidLoginException"/> class.
        /// </summary>
        public InvalidLoginException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidLoginException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidLoginException(string message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when a student's registration fails.
    /// Inherits from <see cref="ServiceException"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RegistrationFailedException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationFailedException"/> class.
        /// </summary>
        public RegistrationFailedException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationFailedException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public RegistrationFailedException(string message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when a section is not found.
    /// Inherits from <see cref="ResourceNotFoundException"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SectionNotFoundException : ResourceNotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SectionNotFoundException"/> class.
        /// </summary>
        public SectionNotFoundException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionNotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SectionNotFoundException(string message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when a student is already registered for a section.
    /// Inherits from <see cref="ServiceException"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentAlreadyRegisteredException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentAlreadyRegisteredException"/> class.
        /// </summary>
        public StudentAlreadyRegisteredException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentAlreadyRegisteredException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public StudentAlreadyRegisteredException(string message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when there is an overlap between sections in a student's schedule.
    /// Inherits from <see cref="ServiceException"/>.
    /// </summary>
    public class SectionOverlapException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SectionOverlapException"/> class.
        /// </summary>
        public SectionOverlapException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionOverlapException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SectionOverlapException(string message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when there is an error in the repository.
    /// Inherits from <see cref="ServiceException"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RepositoryException : ServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryException"/> class.
        /// </summary>
        public RepositoryException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public RepositoryException(string message) : base(message) { }
    }
}
