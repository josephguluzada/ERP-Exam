using System.ComponentModel.DataAnnotations;

namespace ExamProgram.UI.ViewModels.TeacherViewModels
{
    public class TeacherCreateViewModel
    {
        [StringLength(maximumLength:30,ErrorMessage ="maksimum 30 ola bilər"),MinLength(2,ErrorMessage ="min 2 ola bilər")]
        public string Name { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "maksimum 30 ola bilər"), MinLength(2, ErrorMessage = "min 3 ola bilər")]
        public string Surname { get; set; }
    }
}
