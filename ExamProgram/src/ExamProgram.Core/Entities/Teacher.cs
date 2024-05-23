namespace ExamProgram.Core.Entities;

public class Teacher : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public ICollection<Lesson> Lessons { get; set; }
}
