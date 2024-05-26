namespace ExamProgram.Business.ExamProgramApiExceptions.LessonExceptions;

public class LessonCodeAlreadyExistException : Exception, IBaseException
{
    public string PropetyName {  get; set; }
    public string Message {  get; set; }

    public LessonCodeAlreadyExistException()
    {
    }

    public LessonCodeAlreadyExistException(string propertyName, string? message) : base(message)
    {
        PropetyName = propertyName;
        Message = message;
    }
}
