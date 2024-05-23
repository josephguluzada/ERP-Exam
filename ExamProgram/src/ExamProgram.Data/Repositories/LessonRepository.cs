using ExamProgram.Core.Entities;
using ExamProgram.Core.Repositories;
using ExamProgram.Data.DAL;

namespace ExamProgram.Data.Repositories;

internal class LessonRepository : GenericRepository<Lesson>, ILessonRepository
{
    public LessonRepository(DataContext context) : base(context)
    {
    }
}
