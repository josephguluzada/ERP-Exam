
using ExamProgram.Core.Entities;

namespace ExamProgram.Business.DTOs.TeacherDtos;

public record TeacherGetDto(int Id, string Name, string Surname, List<Lesson> Lessons);
