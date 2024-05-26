namespace ExamProgram.UI.ViewModels.ExamViewModels
{
    public class ExamViewModel
    {
        
        public int Id { get; set; }
        public string LessonCode { get; set; }
        public int StudentNumber { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public DateTime ExamDate { get; set; }
        public byte Grade { get; set; }
    }
}
