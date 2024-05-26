using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProgram.Business.ExamProgramApiExceptions.TeacherExceptions
{
    public class TeacherNotFoundException : Exception, IBaseException
    {
        public string PropetyName { get; set; }
        public string Message { get; set; }

        public TeacherNotFoundException()
        {
        }

        public TeacherNotFoundException(string propertyName, string? message) : base(message)
        {
            PropetyName = propertyName;
            Message = message;
        }
    }
}
