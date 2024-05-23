using ExamProgram.Business.DTOs.LessonDtos;

namespace ExamProgram.Business.Services.Interfaces;

public interface ILessonService
{
    Task CreateAsync(LessonCreateDto dto);
    Task<LessonGetDto> GetByIdAsync(int id);
    Task<IEnumerable<LessonGetDto>> GetAllAsync();
    Task UpdateAsync(int id, LessonUpdateDto dto);
    Task DeleteAsync(int id);
}
