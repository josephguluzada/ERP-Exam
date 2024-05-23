namespace ExamProgram.Business.DTOs.LessonDtos;

public record LessonGetDto(int Id, string Code, int ClassNumber, string TeacherName, string TeacherSurname);
