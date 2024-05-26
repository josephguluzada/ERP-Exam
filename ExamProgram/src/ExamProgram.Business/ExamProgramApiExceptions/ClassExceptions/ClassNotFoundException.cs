namespace ExamProgram.Business.ExamProgramApiExceptions.ClassExceptions;

public class ClassNotFoundException : Exception, IBaseException
{
    public string PropetyName { get; set; }
    public string Message { get; set; }

    public ClassNotFoundException()
    {
    }

    public ClassNotFoundException(string propertyName, string? message) : base(message)
    {
        PropetyName = propertyName;
        Message = message;
    }

}
