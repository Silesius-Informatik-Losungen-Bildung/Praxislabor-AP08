namespace StempelAppLib.Exceptions.MapperExceptions
{
    public class AssignmentMapperException : Exception
    {
        public AssignmentMapperException() { }
        public AssignmentMapperException(string message) : base(message) { }
        public AssignmentMapperException(string message, Exception innerException) : base(message, innerException) { }
    }
}