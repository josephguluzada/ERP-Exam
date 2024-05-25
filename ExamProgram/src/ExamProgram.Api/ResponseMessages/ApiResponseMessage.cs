using ExamProgram.Business.ExamProgramApiExceptions;
using ExamProgram.Business.ExamProgramApiExceptions.ClassExceptions;

namespace ExamProgram.Api.ResponseMessages
{
    public class ApiResponseMessage
    {
        public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();

        public static Dictionary<string,string[]> CreateResponseMessage(IBaseException exception)
        {
            Dictionary<string, string[]> keyValues = new Dictionary<string, string[]>();
            keyValues.Add(exception.PropetyName, [exception.Message]);

            return keyValues;
        }
    }
}
