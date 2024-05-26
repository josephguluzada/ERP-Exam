using ExamProgram.Business.DTOs.TokenDtos;
using ExamProgram.Business.DTOs.UserDtos;

namespace ExamProgram.Business.Services.Interfaces;

public interface IAuthService
{
    Task<TokenResponseDto> Login(UserLoginDto userLoginDto);
}
