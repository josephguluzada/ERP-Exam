namespace ExamProgram.Business.ExamProgramApiExceptions;

public interface IBaseException
{
    string PropetyName { get; set; }
    string Message { get; set; }
}
