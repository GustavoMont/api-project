namespace api_project.errors;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message) { }
}
