using ExamProgram.Business.DTOs.TeacherDtos;

namespace ExamProgram.Business.Services.Interfaces;

public interface ITeacherService
{
    Task CreateAsync(TeacherCreateDto dto);
    Task<TeacherGetDto> GetByIdAsync(int id);
    Task<IEnumerable<TeacherGetDto>> GetAllAsync();
    Task UpdateAsync(int id, TeacherUpdateDto dto);
    Task DeleteAsync(int id);
}
