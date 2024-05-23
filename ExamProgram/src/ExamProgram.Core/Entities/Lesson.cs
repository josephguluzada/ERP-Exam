namespace ExamProgram.Core.Entities;

public class Lesson : BaseEntity
{
    public string LessonCode { get; set; } = null!;
    public string LessonName { get; set; } = null!;
    public double ClassNumber { get; set; }
    public string TeacherName { get; set; } = null!;
    public string TeacherSurname { get; set; } = null!;

    public ICollection<Exam> Exams { get; set; }
}
