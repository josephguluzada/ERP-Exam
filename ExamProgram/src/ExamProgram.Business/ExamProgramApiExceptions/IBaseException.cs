namespace ExamProgram.Business.ExamProgramApiExceptions;

public interface IBaseException
{
    public string PropetyName { get; set; }
    public string Message { get; set; }
}
