namespace ExamProgram.Business.DTOs.LessonDtos;

public record LessonGetDto(int Id, string Code,string Name, int ClassNumber, string TeacherName, string TeacherSurname);
