namespace UniversityAPI.Services
{
    public class StudentServiceException : Exception
    {
        public StudentServiceException() : base() { }
        public StudentServiceException(string message) : base(message) { }
    }
}