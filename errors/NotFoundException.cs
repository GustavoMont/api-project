namespace api_project.errors;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}
