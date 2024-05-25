namespace ExamProgram.Business.ExamProgramApiExceptions.StudentExceptions;

public class SameNumberException : Exception, IBaseException
{
    public string PropetyName { get; set; }
    public string Message { get; set; }
    public SameNumberException()
    {
    }

    public SameNumberException(string propertyName,string? message) : base(message)
    {
        PropetyName = propertyName;
        Message = message;
    }

    


}
