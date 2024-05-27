using System.ComponentModel.DataAnnotations;

namespace ExamProgram.UI.ViewModels.ExamViewModels
{
    public class ExamCreateViewModel
    {
        public string LessonCode { get; set; }
        [Range(1,999)]
        public int StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        [Range(1, 5)]
        public byte Grade { get; set; }
    }
}
