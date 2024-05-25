namespace ExamProgram.Business.ExamProgramApiExceptions.CommonExceptions;

public class NotFoundException : Exception, IBaseException
{
    public string PropetyName {  get; set; }
    public string Message { get; set; }

    public NotFoundException()
    {
    }

    public NotFoundException(string propertyName, string? message) : base(message)
    {
        PropetyName = propertyName;
        Message = message;
    }
}
