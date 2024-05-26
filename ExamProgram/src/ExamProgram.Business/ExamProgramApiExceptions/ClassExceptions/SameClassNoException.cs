namespace ExamProgram.Business.ExamProgramApiExceptions.ClassExceptions;

public class SameClassNoException : Exception, IBaseException
{
    public string PropetyName { get; set; }
    public string Message { get ; set ; }

    public SameClassNoException()
    {
    }

    public SameClassNoException(string propertyName,string? message) : base(message)
    {
        PropetyName = propertyName;
        Message = message;
    }
}
