namespace ExamProgram.Business.ExamProgramApiExceptions.UserExceptions;

public class InvalidCredsException : Exception, IBaseException
{
    public string PropetyName { get; set; }
    public string Message { get; set; }

    public InvalidCredsException()
    {
    }

    public InvalidCredsException(string propertyName, string? message) : base(message)
    {
        PropetyName = propertyName;
        Message = message;
    }
}
