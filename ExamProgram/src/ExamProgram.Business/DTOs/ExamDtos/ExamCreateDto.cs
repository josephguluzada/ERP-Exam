namespace ExamProgram.Business.DTOs.ExamDtos;

public record ExamCreateDto(string LessonCode,int StudentNumber, DateTime ExamDate, byte Grade);
