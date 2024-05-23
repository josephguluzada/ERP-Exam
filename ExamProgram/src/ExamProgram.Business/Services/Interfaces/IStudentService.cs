using ExamProgram.Business.DTOs.StudentDtos;

namespace ExamProgram.Business.Services.Interfaces;

public interface IStudentService
{
    Task CreateAsync(StudentCreateDto dto);
    Task<StudentGetDto> GetByIdAsync(int id);
    Task<IEnumerable<StudentGetDto>> GetAllAsync();
    Task UpdateAsync(int id, StudentUpdateDto dto);
    Task DeleteAsync(int id);
}
