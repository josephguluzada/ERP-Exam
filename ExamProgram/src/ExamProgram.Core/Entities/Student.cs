namespace ExamProgram.Core.Entities;

public class Student : BaseEntity
{
    public double StudentNo { get; set; }
    public string Name { get; set; } = null!;
    public string SurName { get; set; } = null!;
    public double ClassNumber { get; set; }

    public ICollection<Exam> Exams { get; set; }
}
