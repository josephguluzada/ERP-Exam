using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProgram.Business.ExamProgramApiExceptions.StudentExceptions
{
    public class StudentNotFoundException : Exception, IBaseException
    {
        public string PropetyName { get; set; }
        public string Message { get; set; }

        public StudentNotFoundException()
        {
        }

        public StudentNotFoundException(string propertyName, string? message) : base(message)
        {
            PropetyName = propertyName;
            Message = message;
        }
    }
}
