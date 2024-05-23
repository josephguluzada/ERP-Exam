using ExamProgram.Core.Entities;
using ExamProgram.Core.Repositories;
using ExamProgram.Data.DAL;

namespace ExamProgram.Data.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(DataContext context) : base(context)
    {
    }
}
