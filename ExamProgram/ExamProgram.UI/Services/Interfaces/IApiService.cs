using ExamProgram.UI.ViewModels.AuthViewModels;

namespace ExamProgram.UI.Services.Interfaces
{
    public interface IApiService
    {
        Task<AuthViewModel> Login(LoginViewModel model);
    }
}
