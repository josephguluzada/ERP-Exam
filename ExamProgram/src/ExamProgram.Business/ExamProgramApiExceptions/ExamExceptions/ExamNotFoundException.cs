namespace ExamProgram.Business.ExamProgramApiExceptions.ExamExceptions;

public class ExamNotFoundException : Exception, IBaseException
{
    public string PropetyName { get; set; }
    public string Message { get; set; }

    public ExamNotFoundException()
    {
    }

    public ExamNotFoundException(string propertyName, string? message) : base(message)
    {
        PropetyName = propertyName;
        Message = message;
    }
}
