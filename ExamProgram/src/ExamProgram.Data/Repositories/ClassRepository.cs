using ExamProgram.Core.Entities;
using ExamProgram.Core.Repositories;
using ExamProgram.Data.DAL;

namespace ExamProgram.Data.Repositories;

public class ClassRepository : GenericRepository<Class>, IClassRepository
{
    public ClassRepository(DataContext context) : base(context)
    {
    }
}
