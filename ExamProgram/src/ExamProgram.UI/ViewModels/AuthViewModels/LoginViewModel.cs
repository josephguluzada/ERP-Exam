using System.ComponentModel.DataAnnotations;

namespace ExamProgram.UI.ViewModels.AuthViewModels
{
    public class LoginViewModel
    {
        [Required]

        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
