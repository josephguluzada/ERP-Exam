namespace ExamProgram.Core.Entities;

public class Exam : BaseEntity
{
    public int LessonId { get; set; }
    public int StudentId { get; set; }
    public DateTime ExamDate { get; set; }
    public byte Grade { get; set; }

    public Lesson Lesson { get; set; }
    public Student Student { get; set; }

}
