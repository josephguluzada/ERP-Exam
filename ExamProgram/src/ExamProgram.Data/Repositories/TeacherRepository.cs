using ExamProgram.Core.Entities;
using ExamProgram.Core.Repositories;
using ExamProgram.Data.DAL;

namespace ExamProgram.Data.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(DataContext context) : base(context)
    {
    }
}
