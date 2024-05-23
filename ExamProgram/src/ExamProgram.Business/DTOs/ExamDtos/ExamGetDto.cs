namespace ExamProgram.Business.DTOs.ExamDtos;

public record ExamGetDto(int Id, string LessonCode, int StudentNumber,string StudentName, string StudentSurname,DateTime ExamDate, byte Grade);
