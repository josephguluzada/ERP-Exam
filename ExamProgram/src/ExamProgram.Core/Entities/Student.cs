namespace ExamProgram.Core.Entities;

public class Student : BaseEntity
{
    public int ClassId { get; set; }
    public int Number { get; set; }
    public string Name { get; set; } = null!;
    public string SurName { get; set; } = null!;

    public ICollection<Exam> Exams { get; set; }
    public Class Class { get; set; }
}
