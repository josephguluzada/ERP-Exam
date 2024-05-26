namespace ExamProgram.Business.DTOs.TokenDtos;

public record TokenResponseDto(string userName, string accessToken, DateTime accessTokenExpire);
