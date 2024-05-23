namespace ExamProgram.Core.Entities;

public class Exam : BaseEntity
{
    public int LessonId { get; set; }
    public int StudentId { get; set; }
    public string LessonCode { get; set; } = null!;
    public double StudentNumber { get; set; }
    public DateTime ExamDate { get; set; }
    public double Grade { get; set; }

    public Lesson Lesson { get; set; }
    public Student Student { get; set; }

}
