namespace ExamProgram.Business.DTOs.LessonDtos;

public record LessonUpdateDto(string Code,string Name,int ClassId, int TeacherId);
