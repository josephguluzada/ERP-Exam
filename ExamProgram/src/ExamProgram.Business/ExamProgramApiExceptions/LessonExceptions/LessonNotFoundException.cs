namespace ExamProgram.Business.ExamProgramApiExceptions.LessonExceptions;

public class LessonNotFoundException : Exception, IBaseException
{
    public string PropetyName { get; set; }
    public string Message { get; set; }

    public LessonNotFoundException()
    {
    }

    public LessonNotFoundException(string propertyName, string? message) : base(message)
    {
        PropetyName = propertyName;
        Message = message;
    }
}
