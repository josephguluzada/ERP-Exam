namespace ExamProgram.Core.Entities;

public class Class : BaseEntity
{
    public int Number { get; set; }

    public ICollection<Student> Students { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
}
