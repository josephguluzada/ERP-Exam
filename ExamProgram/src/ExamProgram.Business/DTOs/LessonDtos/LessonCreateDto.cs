namespace ExamProgram.Business.DTOs.LessonDtos;

public record LessonCreateDto(string Code, string Name, int ClassId, int TeacherId);
