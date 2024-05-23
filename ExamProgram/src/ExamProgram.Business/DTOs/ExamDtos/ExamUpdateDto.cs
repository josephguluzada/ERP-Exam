namespace ExamProgram.Business.DTOs.ExamDtos;

public record ExamUpdateDto(string LessonCode, int StudentNumber, DateTime ExamDate, byte Grade);
