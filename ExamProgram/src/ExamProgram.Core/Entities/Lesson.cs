namespace ExamProgram.Core.Entities;

public class Lesson : BaseEntity
{
    public int TeacherId { get; set; }
    public int ClassId { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
   

    public ICollection<Exam> Exams { get; set; }
    public Class Class { get; set; }
    public Teacher Teacher { get; set; }
}
